using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_Hub.Data;
using Travel_Hub.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Travel_Hub.Controllers
{
    public class WycieczkasController : Controller
    {
        private readonly MyDbContext _context;

        public WycieczkasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Wycieczkas
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchStringName, string liczbaOsob, string dokad, string skad, string maxCena)
        {
            ViewBag.Osrodki  = "";
            ViewBag.maxOs = "";
            ViewBag.dokad = "";
            ViewBag.skad = "";
            ViewBag.maxCena = "";
            var myDbContext = _context.Wycieczka.Include(w => w.Osrodki).AsEnumerable();
            if (!String.IsNullOrEmpty(searchStringName))
            {
                ViewBag.Osrodki = searchStringName;
                var osrodki = _context.Osrodki.Where(o => o.Nazwa_osrodka.Equals(searchStringName)).Select(os => os.OsrodkiId);
                var wycieczki = _context.Wycieczka.Where(w => osrodki.Contains(w.OsrodkiId));
                myDbContext = myDbContext.Intersect(wycieczki);
            }
            if (!String.IsNullOrEmpty(liczbaOsob))
            {
                ViewBag.maxOs = Int32.Parse(liczbaOsob);
                myDbContext = myDbContext.Where(a => a.Max_osob.ToString().Equals( liczbaOsob));
            }
            if (!String.IsNullOrEmpty(dokad))
            {
                ViewBag.dokad = dokad;
                var osrodki = _context.Osrodki.Where(o => o.Adres.Equals(dokad)).Select(os => os.OsrodkiId);
                var wycieczki = _context.Wycieczka.Where(w => osrodki.Contains(w.OsrodkiId));
                myDbContext = myDbContext.Intersect(wycieczki);
            }
            if (!String.IsNullOrEmpty(skad))
            {
                ViewBag.skad = skad;
                var miejsceStartu = _context.OferowaneMiejscaStartu.Where(oms => oms.MiejscaStartu.Nazwa_miejsca.Equals(skad)).Select(w => w.Wycieczka);
                myDbContext = myDbContext.Intersect(miejsceStartu);
            }
            if (!String.IsNullOrEmpty(maxCena))
            {
                ViewBag.maxCena = maxCena;
                myDbContext = myDbContext.Where( w => w.Cena <= Int32.Parse(maxCena));
            }
            return View(myDbContext.ToList());
        }

        // GET: Wycieczkas/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await _context.Wycieczka
                .Include(w => w.Osrodki)
                .FirstOrDefaultAsync(m => m.WycieczkaId == id);

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(14);
            if (Request.Cookies["iloscOs"] == null)
            {
                Response.Cookies.Append("iloscOs", "1", options);

                ViewBag.Price = (wycieczka.Cena * 1);

                ViewBag.Osoby = "1";

                var pokojeDoWyboru = _context.OferowanePokoje.Where(op => op.OsrodkiId == wycieczka.OsrodkiId).Select(op => op.RodzajePokoi).Where(op => op.Pojemnosc >= 1);
                ViewBag.RezButt = "submit";
                if (pokojeDoWyboru.ToList().Count == 0)
                    ViewBag.RezButt = "hidden";
                ViewBag.PokojeDoWyboru = new SelectList(pokojeDoWyboru, "RodzajePokoiId", "Nazwa_rodzaju_pokoju");
            }
            else
            {
                var count = Int32.Parse(Request.Cookies["iloscOs"]);

                ViewBag.Price = (wycieczka.Cena * count);

                ViewBag.Osoby = count;

                var pokojeDoWyboru = _context.OferowanePokoje.Where(op => op.OsrodkiId == wycieczka.OsrodkiId).Select(op => op.RodzajePokoi).Where(op => op.Pojemnosc >= count);
                
                ViewBag.RezButt = "submit";
                if (pokojeDoWyboru.ToList().Count == 0)
                    ViewBag.RezButt = "hidden";
                
                ViewBag.PokojeDoWyboru = new SelectList(pokojeDoWyboru, "RodzajePokoiId", "Nazwa_rodzaju_pokoju");
            }
            
            if (wycieczka == null)
            {
                return NotFound();
            }

            var wyzywienieDoWyboru = _context.OferowaneWyzywienia.Where(ow => ow.OsrodkiId == wycieczka.OsrodkiId).Select(ow => ow.OpcjeWyzywienia);
            ViewBag.WyzywieniaDoWyboru = new SelectList(wyzywienieDoWyboru, "OpcjeWyzywieniaId", "Nazwa_opcji_wyzyw");

            var oferowaneMiejscaStartu = _context.OferowaneMiejscaStartu.Where(oms => oms.WycieczkaId == wycieczka.WycieczkaId).Select(oms => oms.MiejscaStartu);
            ViewBag.MiejscaStartuDoWyboru = new SelectList(oferowaneMiejscaStartu, "MiejscaStartuId", "Nazwa_miejsca");

            return View(wycieczka);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await _context.Wycieczka
                .Include(w => w.Osrodki)
                .FirstOrDefaultAsync(m => m.WycieczkaId == id);

            if (Request.Cookies["iloscOs"] != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(14);
                var count = Int32.Parse(Request.Cookies["iloscOs"]);
                count++;
                
                ViewBag.Osoby = count;
                
                Response.Cookies.Append("iloscOs", count.ToString(), options);
                
                ViewData[id.ToString()] = count.ToString();
                
                var pokojeDoWyboru = _context.OferowanePokoje.Where(op => op.OsrodkiId == wycieczka.OsrodkiId).Select(op => op.RodzajePokoi).Where(op => op.Pojemnosc >= count);
                
                ViewBag.RezButt = "submit";
                if (pokojeDoWyboru.ToList().Count == 0)
                    ViewBag.RezButt = "hidden";
                
                ViewBag.PokojeDoWyboru = new SelectList(pokojeDoWyboru, "RodzajePokoiId", "Nazwa_rodzaju_pokoju");
            }

            var wyzywienieDoWyboru = _context.OferowaneWyzywienia.Where(ow => ow.OsrodkiId == wycieczka.OsrodkiId).Select(ow => ow.OpcjeWyzywienia);
            ViewBag.WyzywieniaDoWyboru = new SelectList(wyzywienieDoWyboru, "OpcjeWyzywieniaId", "Nazwa_opcji_wyzyw");

            var oferowaneMiejscaStartu = _context.OferowaneMiejscaStartu.Where(oms => oms.WycieczkaId == wycieczka.WycieczkaId).Select(oms => oms.MiejscaStartu);
            ViewBag.MiejscaStartuDoWyboru = new SelectList(oferowaneMiejscaStartu, "MiejscaStartuId", "Nazwa_miejsca");

            return RedirectToAction(nameof(Details), new { id = id });
        }

        [AllowAnonymous]
        public async Task<IActionResult> MinusItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await _context.Wycieczka
                .Include(w => w.Osrodki)
                .FirstOrDefaultAsync(m => m.WycieczkaId == id);

            if (Request.Cookies["iloscOs"] != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(14);
                var count = Int32.Parse(Request.Cookies["iloscOs"]);

                count--;

                if (count == 0)
                {
                    ViewBag.Osoby = "1";
                    var pokojeDoWyboru1 = _context.OferowanePokoje.Where(op => op.OsrodkiId == wycieczka.OsrodkiId).Select(op => op.RodzajePokoi).Where(op => op.Pojemnosc >= 1);
                    ViewBag.PokojeDoWyboru = new SelectList(pokojeDoWyboru1, "RodzajePokoiId", "Nazwa_rodzaju_pokoju");
                    ViewBag.RezButt = "submit";
                    if (pokojeDoWyboru1.ToList().Count == 0)
                        ViewBag.RezButt = "hidden";

                    var wyzywienieDoWyboru1 = _context.OferowaneWyzywienia.Where(ow => ow.OsrodkiId == wycieczka.OsrodkiId).Select(ow => ow.OpcjeWyzywienia);
                    ViewBag.WyzywieniaDoWyboru = new SelectList(wyzywienieDoWyboru1, "OpcjeWyzywieniaId", "Nazwa_opcji_wyzyw");

                    var oferowaneMiejscaStartu1 = _context.OferowaneMiejscaStartu.Where(oms => oms.WycieczkaId == wycieczka.WycieczkaId).Select(oms => oms.MiejscaStartu);
                    ViewBag.MiejscaStartuDoWyboru = new SelectList(oferowaneMiejscaStartu1, "MiejscaStartuId", "Nazwa_miejsca");
                    return RedirectToAction(nameof(Details), new { id = id });
                }
                var pokojeDoWyboru = _context.OferowanePokoje.Where(op => op.OsrodkiId == wycieczka.OsrodkiId).Select(op => op.RodzajePokoi).Where(op => op.Pojemnosc >= count);
                ViewBag.PokojeDoWyboru = new SelectList(pokojeDoWyboru, "RodzajePokoiId", "Nazwa_rodzaju_pokoju");
                ViewBag.Osoby = count;
                ViewBag.RezButt = "submit";
                if (pokojeDoWyboru.ToList().Count == 0)
                    ViewBag.RezButt = "hidden";
                Response.Cookies.Append("iloscOs", count.ToString(), options);
                ViewData[id.ToString()] = count.ToString();
            }
            var wyzywienieDoWyboru = _context.OferowaneWyzywienia.Where(ow => ow.OsrodkiId == wycieczka.OsrodkiId).Select(ow => ow.OpcjeWyzywienia);
            ViewBag.WyzywieniaDoWyboru = new SelectList(wyzywienieDoWyboru, "OpcjeWyzywieniaId", "Nazwa_opcji_wyzyw");

            var oferowaneMiejscaStartu = _context.OferowaneMiejscaStartu.Where(oms => oms.WycieczkaId == wycieczka.WycieczkaId).Select(oms => oms.MiejscaStartu);
            ViewBag.MiejscaStartuDoWyboru = new SelectList(oferowaneMiejscaStartu, "MiejscaStartuId", "Nazwa_miejsca");
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // GET: Wycieczkas/Create
        [Authorize(Roles = "Pracownik")]
        public IActionResult Create()
        {
            ViewData["OsrodkiId"] = new SelectList(_context.Osrodki, "OsrodkiId", "Adres");
            return View();
        }

        // POST: Wycieczkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> Create([Bind("WycieczkaId,Max_osob,Cena,Opis,Stan,OsrodkiId")] Wycieczka wycieczka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wycieczka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsrodkiId"] = new SelectList(_context.Osrodki, "OsrodkiId", "Adres", wycieczka.OsrodkiId);
            return View(wycieczka);
        }

        // GET: Wycieczkas/Edit/5
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await _context.Wycieczka.FindAsync(id);
            if (wycieczka == null)
            {
                return NotFound();
            }
            ViewData["OsrodkiId"] = new SelectList(_context.Osrodki, "OsrodkiId", "Adres", wycieczka.OsrodkiId);
            return View(wycieczka);
        }

        // POST: Wycieczkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> Edit(int id, [Bind("WycieczkaId,Max_osob,Cena,Opis,Stan,OsrodkiId")] Wycieczka wycieczka)
        {
            if (id != wycieczka.WycieczkaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wycieczka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WycieczkaExists(wycieczka.WycieczkaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsrodkiId"] = new SelectList(_context.Osrodki, "OsrodkiId", "Adres", wycieczka.OsrodkiId);
            return View(wycieczka);
        }

        // GET: Wycieczkas/Delete/5
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await _context.Wycieczka
                .Include(w => w.Osrodki)
                .FirstOrDefaultAsync(m => m.WycieczkaId == id);
            if (wycieczka == null)
            {
                return NotFound();
            }

            return View(wycieczka);
        }

        // POST: Wycieczkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wycieczka = await _context.Wycieczka.FindAsync(id);
            _context.Wycieczka.Remove(wycieczka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> PotwierdzRezerwacje()
        {
            ViewData["iloscOs"] = Int32.Parse(Request.Cookies["iloscOs"]); //ilosc osob

            var idPokoju = Request.Form["pokojWybrany"].ToString(); //id rodzaju pokoju
            var idWyzyw = Request.Form["wyzywienieWybrane"].ToString(); //id opcji wyzywienia
            var idMiejsca = Request.Form["miejsceStartuWybrane"].ToString(); //miejsce startu id
            var nazwaPokoju = await _context.RodzajePokoi.FirstOrDefaultAsync(p => p.RodzajePokoiId == Int32.Parse(idPokoju));
            var nazwaWyzyw = await _context.OpcjeWyzywienia.FirstOrDefaultAsync(p => p.OpcjeWyzywieniaId == Int32.Parse(idWyzyw));
            var nazwaMiejsca = await _context.MiejscaStartu.FirstOrDefaultAsync(p => p.MiejscaStartuId == Int32.Parse(idMiejsca));
            ViewData["pokojWybrany"] = nazwaPokoju.Nazwa_rodzaju_pokoju;
            ViewData["wyzywienieWybrane"] = nazwaWyzyw.Nazwa_opcji_wyzyw;
            ViewData["miejsceStartuWybrane"] = nazwaMiejsca.Nazwa_miejsca;
            ViewData["pokojWybranyId"] = nazwaPokoju.RodzajePokoiId;
            ViewData["wyzywienieWybraneId"] = nazwaWyzyw.OpcjeWyzywieniaId;
            ViewData["miejsceStartuWybraneId"] = nazwaMiejsca.MiejscaStartuId;

            var idWycieczki = Request.Form["idWycieczki"].ToString();// id wycieczki

            var wycieczka = await _context.Wycieczka
                .Include(w => w.Osrodki)
                .FirstOrDefaultAsync(m => m.WycieczkaId == Int32.Parse(idWycieczki));

            if (wycieczka == null)
            {
                return NotFound();
            }

            ViewData["Price"] = wycieczka.Cena * Int32.Parse(Request.Cookies["iloscOs"]);
            for (int i = 0; i < Int32.Parse(Request.Cookies["iloscOs"]); i++)
            {
                ViewData["plec"+i] = "plec" + i;
                ViewData["imie" + i] = "plec" + i;
                ViewData["nazwisko" + i] = "plec" + i;
            }

            return View(wycieczka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> RejestrujRezerwacje([Bind("WybranePokojeId,OsrodkiId,RodzajePokoiId")] WybranePokoje wybranePokoje
            , [Bind("WybraneWyzywieniaId,OsrodkiId,OpcjeWyzywieniaId")] WybraneWyzywienia wybraneWyzywienia
            , [Bind("RezerwacjaId,Data_zlorzenia,Status,Zaliczka,Liczba_uczestnikow,Dane_osobowe,WycieczkaId,WybranePokojeId,WybraneWyzywieniaId,OferowaneMiejscaStartuId,UserId")] Rezerwacja rezerwacja)
        {

            var iloscOs = Int32.Parse(Request.Cookies["iloscOs"]);
            var miejsceStartuId = Int32.Parse(Request.Form["MiejsceStartuId"]);
            var wyzywienieId = Request.Form["WyzywienieId"];
            var pokojId = Request.Form["PokojId"];
            var osrodekId = Request.Form["OsrodekId"];
            var wycieczkaId = Int32.Parse(Request.Form["WycieczkaId"]);
            var price = Int32.Parse(Request.Form["Price"]);
            var daneOsobowe = "";
            for (int i = 0; i < iloscOs; i++)
            {
                daneOsobowe = daneOsobowe + Request.Form["plec" + i] + ",";
                daneOsobowe = daneOsobowe + Request.Form["imie" + i] + ",";
                daneOsobowe = daneOsobowe + Request.Form["nazwisko" + i] + ";";
            }
            rezerwacja.Data_zlorzenia = DateTime.Now.ToString();
            rezerwacja.Status = StatusRezerwacji.Oczekuje_na_oplate;
            rezerwacja.Zaliczka = price * 0.1f;
            rezerwacja.Liczba_uczestnikow = iloscOs;
            rezerwacja.Dane_osobowe = daneOsobowe;
            rezerwacja.WycieczkaId = wycieczkaId;
            int idOferowanegoMiejsca = _context.OferowaneMiejscaStartu.Where(oms => oms.WycieczkaId == wycieczkaId).Where(oms => oms.MiejscaStartuId == miejsceStartuId).Select(oms => oms.OferowaneMiejscaStartuId).FirstOrDefault();
            rezerwacja.OferowaneMiejscaStartuId = idOferowanegoMiejsca;
            if (ModelState.IsValid)
            {
                _context.Add(wybraneWyzywienia);
                await _context.SaveChangesAsync();
            }
            if (ModelState.IsValid)
            {
                _context.Add(wybranePokoje);
                await _context.SaveChangesAsync();
            }
            rezerwacja.WybranePokojeId = wybranePokoje.WybranePokojeId;
            rezerwacja.WybraneWyzywieniaId = wybraneWyzywienia.WybraneWyzywieniaId;
            rezerwacja.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool WycieczkaExists(int id)
        {
            return _context.Wycieczka.Any(e => e.WycieczkaId == id);
        }
    }
}
