﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeApi.Models;

namespace ProjeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjeController : ControllerBase
    {
        ProjeTurController projeTurController = new ProjeTurController();

        public static List<Proje> projeList = new List<Proje>()
        {
            new Proje
            {
                Id = 1,
                ProjeTurId = 1,
                ProjeNo = "LSNS-1",
                ProjeTitle = "Örnek Lisans Projesi",
                ProjeDate = "09-01-2022"
            },
            new Proje
            {
                Id = 2,
                ProjeTurId = 1,
                ProjeNo = "LSNS-2",
                ProjeTitle = "Örnek Lisans Projesi 2",
                ProjeDate = "09-01-2022"
            },
            new Proje
            {
                Id = 3,
                ProjeTurId = 2,
                ProjeNo = "DKTR-1",
                ProjeTitle = "Örnek Doktora Projesi",
                ProjeDate = "09-01-2022"
            },
            new Proje
            {
                Id = 4,
                ProjeTurId = 2,
                ProjeNo = "DKTR-2",
                ProjeTitle = "Örnek Doktora Projesi 2",
                ProjeDate = "09-12-2021"
            }
        };

        [HttpGet]
        public List<Proje> proje()
        {
            return projeList;
        }

        [HttpGet("{id}")]

        public Proje projeGetById(int id)
        {
            var proje = projeList.Where(x => x.Id == id).SingleOrDefault();
            return proje;
        }

       /* [HttpGet]
        public Proje QueryList([FromQuery] string title)
        {
            var proje = projeList.Where(x => x.ProjeTitle == title).SingleOrDefault();

            return proje;
        }*/


        /*
         * Proje Ekleme
         */
        [HttpPost]
        public IActionResult AddProje([FromBody] Proje projeAdd)
        {
            //var projeTur = projeTurController.ProjeTuruVarmi(projeAdd.ProjeTurId);
            var proje = projeList.SingleOrDefault(x => x.Id == projeAdd.Id);

           /* if (projeTur.Id > 0)
                return NotFound("Proje Türü Bulunamadı");*/
            if(proje is not null)
                return NotFound("Proje Var zaten");

            projeList.Add(projeAdd);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut("{id}")]
        public IActionResult updateProje(Proje updateProje, int id)
        {
            var proje = projeList.SingleOrDefault(x => x.Id == id);

            if (proje == null)
                return NotFound("Proje Bulunamadı");

            proje.ProjeTitle = updateProje.ProjeTitle != default ? updateProje.ProjeTitle : proje.ProjeTitle;
            proje.ProjeTurId = updateProje.ProjeTurId != default ? updateProje.ProjeTurId : proje.ProjeTurId;
            proje.ProjeNo = updateProje.ProjeNo != default ? updateProje.ProjeNo : proje.ProjeNo;

            return Ok();

        }

        [HttpPatch("{id:int}")]
        public IActionResult patchProje(int id, Proje patProje)
        {
            var proje = projeList.SingleOrDefault(x => x.Id == id);

            if (proje == null)
                return NotFound("Proje Bulunamadı");

            proje.ProjeTitle = patProje.ProjeTitle != default ? patProje.ProjeTitle : proje.ProjeTitle;

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult deleteProje(int id)
        {
            var proje = projeList.SingleOrDefault(x => x.Id == id);

            if (proje == null)
                return NotFound("Proje Bulunamadı");
            projeList.Remove(proje);
            return Ok();
        }
    }
}
