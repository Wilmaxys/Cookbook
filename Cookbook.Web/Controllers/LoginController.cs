using Cookbook.API.Models.Login;
using Cookbook.Web.Models.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cookbook.Web.Controllers
{
    public class LoginController : BaseController
    {

        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            return View(new LoginModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Index(LoginModel vm)
        {

            if (ModelState.IsValid)
            {

                bool userExists = false;


                using (var entities = new CookBookEntities1())
                {
                    if (ModelState.IsValid)
                    {
                        HttpResponseMessage response = HttpClient.PostAsJsonAsync("/api/login", vm).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var loginJson = response.Content.ReadAsStringAsync().Result;

                            var login = JsonConvert.DeserializeObject<UserResponseDTO>(loginJson);

                            if (login.isValid == true)
                            {
                                userExists = true;
                            }
                        }
                        else
                        {
                            //TODO: afficher erreur
                        }
                        
                    }
                }


                if (userExists)
                {
                    FormsAuthentication.SetAuthCookie(vm.Email, false);

                    if (!string.IsNullOrWhiteSpace(vm.ReturnUrl) && Url.IsLocalUrl(vm.ReturnUrl))
                    {
                        return Redirect(vm.ReturnUrl);
                    }
                }
                else
                {
                    ViewBag.error = "Le formulaire n'est pas valide";
                    return View(vm);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Create()
        {
            return View(new ApplicationUserModel());
        }

        public ActionResult SaveUser(ApplicationUserModel vm)
        {
            if (ModelState.IsValid && vm != null)
            {
                using (var entities = new CookBookEntities1())
                {
                    try
                    {
                        var person = vm.ApplicationUserId == 0 ? new ApplicationUser() : entities.ApplicationUsers.FirstOrDefault( obj => obj.ApplicationUserId == vm.ApplicationUserId);

                        //Mise à jour des propriétés de l'objet
                        person.FirstName = vm.FirstName;
                        person.LastName = vm.LastName;
                        person.Email = vm.Email;
                        person.Password = vm.Password;
                        person.ApplicationRole = entities.ApplicationRoles.FirstOrDefault(role => role.ApplicationRoleId == 1);

                        if (person.ApplicationUserId == 0)
                            entities.ApplicationUsers.Add(person);

                        entities.SaveChanges();

                        ViewBag.Message = "Sauvegarde réussie";
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = $"Erreur lors de la sauvegarde: {e.Message}";
                    }

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag["ErrorMessage"] = "Le formulaire n'est pas valide";
                return RedirectToAction("Create","Login");
            }

        }

        public ActionResult Delete(int id)
        {

            using (var entities = new CookBookEntities1())
            {
                var recipe = entities.Recipes.Where(obj => obj.Id == id).SingleOrDefault();

                if (recipe != null)
                {
                    entities.Recipes.Remove(recipe);

                    entities.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    
    }
}