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
      Post["/"] = _ =>
      {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();

        List<Stylist> allStylists = Stylist.GetAll();

        return View["index.cshtml", allStylists];
      };
    }
  }
}
