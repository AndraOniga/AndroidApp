using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectTry.Models;

namespace ProiectTry.Data
{
    public class EchipamentDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public EchipamentDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<EchipamentAlpin>().Wait();
            _database.CreateTableAsync<Echipament>().Wait(); 
            _database.CreateTableAsync<ListEchipament>().Wait();

        }
        public Task<int> SaveEchipamenttAAsync(Echipament echipament) { if (echipament.ID != 0) { return _database.UpdateAsync(echipament); } else { return _database.InsertAsync(echipament); } }
        public Task<int> DeleteEchipamentAAsync(Echipament echipament) { return _database.DeleteAsync(echipament); }
        public Task<List<Echipament>> GetEchipamentsAsync()
        { return _database.Table<Echipament>().ToListAsync(); }
        public Task<List<EchipamentAlpin>> GetEchipamentAlpinsAsync()
        {
            return _database.Table<EchipamentAlpin>().ToListAsync();
        }
        public Task<EchipamentAlpin> GetEchipamentAlpinAsync(int id)
        {
            return _database.Table<EchipamentAlpin>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveEchipamentAlpinAsync(EchipamentAlpin slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeleteEchipamentAlpinAsync(EchipamentAlpin slist) { return _database.DeleteAsync(slist); }
        public Task<int> SaveListEchipamentAsync(ListEchipament listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Echipament>> GetListEchipamentsAsync(int shoplistid)
        {
            return _database.QueryAsync<Echipament>("select P.ID, P.Denumire from Echipament P" + " inner join ListEchipament LP" + " on P.ID = LP.EchipamentID where LP.EchipamentAlpinID = ?", shoplistid);
        }
        public Task<int> DeleteListEchipamentAsync(ListEchipament listp)
        {
            return _database.DeleteAsync(listp);
        }

        public Task<List<ListEchipament>> GetListEchipamente()
        {
            return _database.QueryAsync<ListEchipament>("select * from ListEchipament");
        }
    }
}
