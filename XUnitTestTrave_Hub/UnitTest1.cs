using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel_Hub.Controllers;
using Travel_Hub.Data;
using Travel_Hub.Models;
using Xunit;

namespace XUnitTestTrave_Hub
{
    public class UnitTest1
    {
        private Wycieczka wycieczka = new Wycieczka() { Max_osob = 15, Cena = 950f, Opis = "test", Stan = StanWycieczki.Potwierdzona, OsrodkiId = 1 };
        private MyDbContext context;
        private WycieczkasController myControler;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "Travel_Hub_v2").Options;
            context = new MyDbContext(options);
            myControler = new WycieczkasController(context);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsIndexWithTourList()
        {
            var result = myControler.Index(null, null, null, null, "1200").Result as ViewResult;
            Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Wycieczka>>(result.Model);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewCreate()
        {
            var result = myControler.Create();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_ModelStateValid_CreatesNewModelAndRedirectsToIndexAction()
        {
            var result = myControler.Create(wycieczka).Result;

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            var testTour = context.Wycieczka.FirstOrDefault(t => t.Opis == wycieczka.Opis);

            Assert.Equal("Index", viewResult.ActionName);
            Assert.Equal(wycieczka.Opis, testTour.Opis);
            Assert.Equal(wycieczka.Cena, testTour.Cena);
        }

        [Fact]
        public void Edit_ValiId_ReturnsViewEditWithModel()
        {
            context.Add(wycieczka);
            context.SaveChanges();
            int id = context.Wycieczka.Where(t => t.Opis == wycieczka.Opis).Select(tour => tour.WycieczkaId).First();

            var result = myControler.Edit(id).Result;

            var viewResult = Assert.IsType<ViewResult>(result);
            var testTour = Assert.IsType<Wycieczka>(viewResult.Model);
            Assert.Equal(id, testTour.WycieczkaId);
            Assert.Equal(wycieczka.Opis, testTour.Opis);
        }

        [Fact]
        public void Edit_InvalidId_Returns404NoFound()
        {
            var result = myControler.Edit(-1).Result;
            var code = Assert.IsType<NotFoundResult>(result) as StatusCodeResult;
            Assert.Equal(404, code.StatusCode);
        }

        [Fact]
        public void Delete_InvalidId_PageNotFound()
        {
            context.Add(wycieczka);
            context.SaveChanges();
            int id = context.Wycieczka.Where(t => t.Opis == wycieczka.Opis).Select(tour => tour.WycieczkaId).First();

            var result = myControler.Delete(-1).Result;

            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteConfirmed_ValidId_DeletesModelAndRedirectsToActionIndex()
        {
            context.Add(wycieczka);
            context.SaveChanges();
            int id = context.Wycieczka.Where(t => t.Opis == wycieczka.Opis).Select(tour => tour.WycieczkaId).First();

            var result = myControler.DeleteConfirmed(id).Result;

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", viewResult.ActionName);

            var testTour = context.Wycieczka.FirstOrDefault(t => t.WycieczkaId == id);
            Assert.Null(testTour);
        }


        //klasy do testowania index detale addItem minusItem PotwierdzRezerwacje RejestrujRezerwacje
    }
}
