using Nancy;
using System.Collections.Generic;
using System;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };
      Get["/stylists"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylists/new"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Post["/stylists/new"] = _ =>
      {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();

        List<Stylist> allStylists = Stylist.GetAll();

        return View["stylists.cshtml", allStylists];
      };
      Get["/clients"] = _ =>
      {
        List<Client> allClients = Client.GetAll();
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("allClients", allClients);
        model.Add("allStylists", allStylists);
        return View["clients.cshtml", model];
      };
      Post["/clients/new"] = _ =>
      {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();

        List<Client> allClients = Client.GetAll();
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("allClients", allClients);
        model.Add("allStylists", allStylists);
        return View["clients.cshtml", model];
      };
      Get["/stylist/delete/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", selectedStylist];
      };
      Delete["/stylist/delete/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylist/edit/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", selectedStylist];
      };
      Patch["/stylist/edit/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Update(Request.Form["stylist-name"]);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["stylists/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist selectedStylist = Stylist.Find(parameters.id);
        List<Client> stylistsClients = selectedStylist.GetClients();
        List<Client> allClients = Client.GetAll();
        model.Add("stylist", selectedStylist);
        model.Add("stylistsClients", stylistsClients);
        model.Add("allClients", allClients);
        return View["stylist.cshtml", model];
      };

      Get["/client/delete/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        return View["client_delete.cshtml", selectedClient];
      };
      Delete["/client/delete/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        List<Client> allClients = Client.GetAll();
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("allClients", allClients);
        model.Add("allStylists", allStylists);
        return View["clients.cshtml", model];
      };
      Get["/client/edit/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        return View["client_edit.cshtml", selectedClient];
      };
      Patch["/client/edit/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Update(Request.Form["client-name"]);
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
    }
  }
}
