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
      Get["/stylists/{id}"] = parameters =>
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
    }
  }
}
