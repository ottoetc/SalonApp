using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_ClientsStartsEmpty()
    {
      int result = Client.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_EqualOverrideTrueForSameName()
    {
      Client testClient1 = new Client("John Doe", 1);
      Client testClient2 = new Client("John Doe", 1);

      Assert.Equal(testClient1, testClient2);
    }
    [Fact]
    public void Test_Save_SavesClientToDatabase()
    {
      Client testClient = new Client("John Doe", 1);
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToClientObject()
    {
      Client testClient = new Client("John Doe", 1);

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsClientInDatabase()
    {
      Client testClient = new Client("John Doe", 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }
    [Fact]
    public void Test_Update_ClientName()
    {
      Client testClient = new Client("John Doe", 1);
      testClient.Save();
      testClient.Update("Nathan Otto", 1);

      Client newClient = new Client("Nathan Otto", 1);

      Assert.Equal(testClient.GetName(), newClient.GetName());
    }
  }
}
