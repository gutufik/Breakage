using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakage.Data
{
    public class DataAccess
    {
        public delegate void RefreshListDelegate();
        public static event RefreshListDelegate RefreshList;

        public static List<Client> GetClients()
        {
            return BreakageMishaEntities.GetContext().Clients.ToList();
        }

        public static List<Service> GetServices()
        {
            return BreakageMishaEntities.GetContext().Services.ToList();
        }

        public static List<Gender> GetGenders()
        {
            return BreakageMishaEntities.GetContext().Genders.ToList();
        }

        public static void SaveClient(Client client)
        {
            if (client.ID == 0)
                BreakageMishaEntities.GetContext().Clients.Add(client);

            BreakageMishaEntities.GetContext().SaveChanges();
            RefreshList?.Invoke();
        }

        public static void DeleteClient(Client client)
        {
            BreakageMishaEntities.GetContext().Clients.Remove(client);
            BreakageMishaEntities.GetContext().SaveChanges();
            RefreshList?.Invoke();
        }
    }
}
