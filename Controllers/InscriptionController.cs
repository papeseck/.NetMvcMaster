using MvcGlAtelier2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcGlAtelier2023.Controllers
{
    public class InscriptionController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();
        int pageSize = 4;
        // GET: Client/Create
        public ActionResult listerClient (int? page ,string Prenom ,string Nom)

        {
            page = page.HasValue ? page : 1;
            var liste = getListeClient();
            ViewBag.Prenom= Prenom;
            ViewBag.Nom= Nom;
            if (!string.IsNullOrEmpty(Nom))
            {
                liste= liste.Where(a => a.NomPers.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.PrenomPers.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }
            int pageNumber = (page ?? 1);
            return View(liste.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        private List <ClientViewModel> getListeClient()
        {
            List<ClientViewModel> lister = new List<ClientViewModel>();
           var liste = db.clients.Join(db.personnes , x=>x.IdPers,y =>y.IdPers ,(x,y) =>
            new {x.IdPers ,x.Sexe,y.AdresPers,y.EmailPers,y.PrenomPers,y.NomPers,y.telPers }).ToList();

                foreach( var i in liste)
            {
                ClientViewModel c = new ClientViewModel();
                c.IdPers= i.IdPers;
                c.PrenomPers = i.PrenomPers;
                c.NomPers = i.NomPers;
                c.telPers = i.telPers;
                c.EmailPers= i.EmailPers;
                c.Sexe= i.Sexe;
                c.AdresPers= i.AdresPers;
                lister.Add(c);

            }

            return lister;
        }

        // POST: Clients/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPers,NomPers,PrenomPers,AdresPers,EmailPers,Sexe,telPers")] ClientViewModel cl)
        {
            if (ModelState.IsValid)
            {
                Personne p = new Personne();
                p.NomPers = cl.NomPers;
                p.PrenomPers= cl.PrenomPers;
                p.AdresPers= cl.AdresPers;
                p.EmailPers= cl.EmailPers;
                p.telPers= cl.telPers;
                db.personnes.Add(p);
                db.SaveChanges();
                Client c = new Client();
                c.IdPers=p.IdPers;
                c.Sexe=cl.Sexe;
                db.clients.Add(c);
                db.SaveChanges();
                return RedirectToAction("/listerClient");
            }

            return View(cl);
        }
    }
}