using LeGrandRestaurant.Test.Helpers;
using System.Collections.Generic;
using Xunit;

namespace LeGrandRestaurant.Test.Unit
{
    public class InstallationClientTest
    {
        [Fact(DisplayName = "La table est libre à sa création")]
        public void CréerUneTable()
        {
            Table table = new TableBuilder().Build();
            Assert.True(table.libre());
        }

        [Fact(DisplayName="Affecter table à un client")]
        public void AffecterTableClient_RetirerLaTableDansLaListeDesTables()
        {
            Table table = new TableBuilder().Build();

            Client client = new Client();
            table.AffecterA(client);

            Assert.False(table.libre());
        }

        [Fact(DisplayName = "Retirer table quand le client part")]
        public void DépartClient_RemetLaTable()
        {
            Table table = new TableBuilder().Build();

            Client client = new Client();
            table.AffecterA(client);

            table.Libérer();

            Assert.True(table.libre());
        }
    }
}
