using Nancy;
using HairSalon;
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
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Post["/stylist/new"] = _ =>
      {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();

        List<Stylist> allStylists = Stylist.GetAll();

        return View["index.cshtml", allStylists];
      };
      Get["/stylist/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedStylist = Stylist.Find(parameters.id);
        var StylistsClients = SelectedStylist.GetClients();
        model.Add("stylist", SelectedStylist);
        model.Add("clients", StylistsClients);
        return View["stylist.cshtml", model];
      };
      Post["/client/new"] = _ =>
      {
        Client newClient = new Client(Request.Form["client-name"]);
        newClient.Save();

        List<Client> allClients = Client.GetAll();

        return View["stylist.cshtml", allClients];
      };
      Get["/stylist/edit/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["edit_stylist.cshtml", selectedStylist];
      };
      Patch["/stylist/edit/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Update(Request.Form["stylist-name"]);
        return View["index.cshtml"];
      };
      Delete["/stylist/delete/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Delete();
        return View["index.cshtml"];
      };
      Get["/client/edit/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        return View["edit_client.cshtml", selectedClient];
      };
      Patch["/client/edit/{id}"] = parameters =>
      {
        Client selectedStylist = Client.Find(parameters.id);
        selectedClient.Update(Request.Form["client-name"]);
        return View["stylist.cshtml"];
      };
      Delete["/client/delete/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        return View["stylist.cshtml"];
      };
    }
  }
}
