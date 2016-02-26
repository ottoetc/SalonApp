using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_StylistsStartsEmpty()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_EqualOverrideTrueForSameName()
    {
      Stylist testStylist1 = new Stylist("John Doe");
      Stylist testStylist2 = new Stylist("John Doe");

      Assert.Equal(testStylist1, testStylist2);
    }
    [Fact]
    public void Test_Save_SavesStylistToDatabase()
    {
      Stylist testStylist = new Stylist("Nathan Otto");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToStylistObject()
    {
      Stylist testStylist = new Stylist("Nathan Otto");

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Nathan Otto");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void Test_Update_StylistName()
    {
      Stylist testStylist = new Stylist("Nathan Otto");
      testStylist.Save();
      testStylist.Update("Jane Doe");

      Stylist newStylist = new Stylist("Jane Doe");

      Assert.Equal(testStylist.GetName(), newStylist.GetName());
    }
    [Fact]
    public void Test_Delete_DeletesStylistFromDatabase()
    {
      Stylist testStylist1 = new Stylist("Nathan Otto");
      testStylist1.Save();

      Stylist testStylist2 = new Stylist("Jane Doe");
      testStylist2.Save();

      testStylist1.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist>{testStylist2};

      Assert.Equal(testStylistList, resultStylists);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
