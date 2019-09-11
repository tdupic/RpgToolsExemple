using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioJdr;
using BiblioJdr.metier;
using BiblioJdr.outils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BPersistance.bdd
{
    public class JdrDBManager : IDataManager
    {
        JdrDBEntities Context { get; set; }
        private bool UseInMemory { get; set; }
        public JdrDBManager() : this(false)
        {

        }

        public JdrDBManager(bool useInMemoryDatabase)
        {
            UseInMemory = useInMemoryDatabase;
            //if (UseInMemory) { InitJdrDBEntities(); }
            InitJdrDBEntities();
        }


        public JdrDBEntities InitJdrDBEntities()
        {
            try
            {
                if (!UseInMemory)
                {
                    Context = new JdrDBEntities();
                    Context.Database.OpenConnection();
                    Context.Database.EnsureCreated();
                    return Context;
                }
                else
                {
                    if (Context != null) return Context;

                    var connectionStringBuilder =
                        new SQLiteConnectionStringBuilder { DataSource = ":memory:" };
                    var connectionString = connectionStringBuilder.ToString();
                    var connection = new SqliteConnection(connectionString);

                    DbContextOptions<JdrDBEntities> options;
                    var builder = new DbContextOptionsBuilder<JdrDBEntities>();
                    builder.UseSqlite(connection);
                    options = builder.Options;

                    Context = new JdrDBEntities(options);
                    Context.Database.OpenConnection();
                    Context.Database.EnsureCreated();
                    return Context;
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                throw e;
            }
        }

        public async Task<T> AddAsync<T>(T item) where T : class
        {
            T result = default(T);
            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                if (item == null) return default(T);
                try
                {
                    if (typeof(T) == typeof(IPersonnage))
                    {
                        var temp = (await Context.PersonnageSet.AddAsync(item as Personnage)).Entity as Personnage;
                        foreach (Item it in (item as Personnage).ROCInventaire)
                        {
                            await Context.ItemSet.AddAsync(it);
                        }
                        
                        result = temp as T;
                    }
                    else if (typeof(T) == typeof(Arme))
                    {
                        var temp = (await Context.ItemSet.AddAsync(item as Arme)).Entity as Arme;
                        result = temp as T;
                    }
                    else if (typeof(T) == typeof(Armure))
                    {
                        var temp = (await Context.ItemSet.AddAsync(item as Armure)).Entity as Armure;
                        result = temp as T;
                    }
                    else if (typeof(T) == typeof(Nouriture))
                    {
                        var temp = (await Context.ItemSet.AddAsync(item as Nouriture)).Entity as Nouriture;
                        result = temp as T;
                    }
                    else if (typeof(T) == typeof(Potion))
                    {
                        var temp = (await Context.ItemSet.AddAsync(item as Potion)).Entity as Potion;
                        result = temp as T;
                    }
                    else if (typeof(T) == typeof(Divers))
                    {
                        var temp = (await Context.ItemSet.AddAsync(item as Divers)).Entity as Divers;
                        result = temp as T;
                    }
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Debug.WriteLine((e.Message));
                    transaction.Rollback();
                }
            }
            return result;
        }

        public async Task<bool> ExistsAsync<T>(T item) where T : class
        {
            using (UseInMemory ? null : InitJdrDBEntities())
            {
                if (item == null) return false;
                bool result = false;
                try
                {
                    if (typeof(T) == typeof(Personnage))
                    {
                        result = await Context.PersonnageSet.FindAsync((item as Personnage).Nom) != null;
                    }
                    else if (typeof(T) == typeof(Arme))
                    {
                        result = await Context.PersonnageSet.FindAsync((item as Arme).Nom) != null;
                    }
                    else if (typeof(T) == typeof(Armure))
                    {
                        result = await Context.PersonnageSet.FindAsync((item as Armure).Nom) != null;
                    }
                    else if (typeof(T) == typeof(Nouriture))
                    {
                        result = await Context.PersonnageSet.FindAsync((item as Nouriture).Nom) != null;
                    }
                    else if (typeof(T) == typeof(Potion))
                    {
                        result = await Context.PersonnageSet.FindAsync((item as Potion).Nom) != null;
                    }
                    else if (typeof(T) == typeof(Divers))
                    {
                        result = await Context.PersonnageSet.FindAsync((item as Divers).Nom) != null;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public async Task<List<IPersonnage>> GetPersonnageAsync()
        {
            List<IPersonnage> lesPersosDB = new List<IPersonnage>();
            using (UseInMemory ? null : InitJdrDBEntities())
            {
                try
                {
                    /*foreach(IPersonnage p in Context.PersonnageSet)
                    {
                        //Peut etre utiliser SingleOrDefaultAsync
                        lesPersosDB.Add(p);
                    }*/
                    return await Context.PersonnageSet.Select(pDB => (pDB as Personnage) as IPersonnage).ToListAsync();
                } catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                
            }
            return lesPersosDB;
        }


        public async Task<T> GetAsync<T>(T item) where T : class
        {
            using (UseInMemory ? null : InitJdrDBEntities())
            {
                if (item == null) return default(T);
                T result = default(T);
                try
                {
                    if (typeof(T) == typeof(Personnage))
                    {
                        var personneDB = await Context.PersonnageSet.SingleOrDefaultAsync(pdb => pdb.Equals(item));
                        result = (personneDB as Personnage) as T;
                    }
                    else if (typeof(T) == typeof(Arme))
                    {
                        var armeDB = await Context.ItemSet.SingleOrDefaultAsync(pdb => pdb.Equals(item));
                        result = (armeDB as Arme) as T;
                    }
                    else if (typeof(T) == typeof(Armure))
                    {
                        var armureDB = await Context.ItemSet.SingleOrDefaultAsync(pdb => pdb.Equals(item));
                        result = (armureDB as Armure) as T;
                    }
                    else if (typeof(T) == typeof(Potion))
                    {
                        var potionDB = await Context.ItemSet.SingleOrDefaultAsync(pdb => pdb.Equals(item));
                        result = (potionDB as Potion) as T;
                    }
                    else if (typeof(T) == typeof(Divers))
                    {
                        var diversDB = await Context.ItemSet.SingleOrDefaultAsync(pdb => pdb.Equals(item));
                        result = (diversDB as Divers) as T;
                    }
                    else if (typeof(T) == typeof(Nouriture))
                    {
                        var nourDB = await Context.ItemSet.SingleOrDefaultAsync(pdb => pdb.Equals(item));
                        result = (nourDB as Nouriture) as T;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetItems<T>(int index, int count) where T : class
        {
            using (UseInMemory ? null : InitJdrDBEntities())
            {
                List<T> result = new List<T>();
                if (count == 0) return result;
                try
                {
                    if (typeof(T) == typeof(Personnage))
                    {
                        var query = Context.PersonnageSet.Skip(index);
                        query = count == -1 ? query : query.Take(count);
                        return await query.Select(pDB => (pDB as Personnage) as T).ToListAsync();
                    }
                    else if (typeof(T) == typeof(Arme))
                    {
                        var query = Context.ItemSet.Skip(index);
                        query = count == -1 ? query : query.Take(count);
                        return (await query.ToListAsync()).Select(pDB => (pDB as T));
                    }
                    else if (typeof(T) == typeof(Armure))
                    {
                        var query = Context.ItemSet.Skip(index);
                        query = count == -1 ? query : query.Take(count);
                        return (await query.ToListAsync()).Select(pDB => (pDB as T));
                    }
                    else if (typeof(T) == typeof(Potion))
                    {
                        var query = Context.ItemSet.Skip(index);
                        query = count == -1 ? query : query.Take(count);
                        return (await query.ToListAsync()).Select(pDB => (pDB as T));
                    }
                    else if (typeof(T) == typeof(Divers))
                    {
                        var query = Context.ItemSet.Skip(index);
                        query = count == -1 ? query : query.Take(count);
                        return (await query.ToListAsync()).Select(pDB => (pDB as T));
                    }
                    else if (typeof(T) == typeof(Nouriture))
                    {
                        var query = Context.ItemSet.Skip(index);
                        query = count == -1 ? query : query.Take(count);
                        return (await query.ToListAsync()).Select(pDB => (pDB as T));
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;

            }
        }

        public async Task<bool> RemoveItemAsync(Item item)
        {
            if (item == null) return false;

            var idb = await Context.ItemSet.FindAsync(item.Nom);

            var result = Context.ItemSet.Remove(item).Entity;
            await Context.SaveChangesAsync();

            return result != null;
        }

        public async Task<bool> RemovePersonnageAsync(Personnage prs)
        {
            if (prs == null) return false;

            var pdb = await Context.PersonnageSet.FindAsync(prs.Nom);

            var result = Context.PersonnageSet.Remove(prs).Entity;
            await Context.SaveChangesAsync();

            return result != null;
        }

        public Task Clear<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(T item) where T : class
        {
            if (!ExistsAsync(item).Result) return null;
            using (UseInMemory ? null : InitJdrDBEntities())
            {
                T result = null;
                using (var transaction = await Context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (typeof(T) == typeof(IPersonnage))
                        {
                            result = (T)(await UpdatePersonnage((IPersonnage)item) as IPersonnage);
                        }
                        else if (typeof(T) == typeof(IItem))
                        {
                            result = (T)(await UpdateItemAsync((IItem)item) as IItem);
                        }
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
                return result;
            }
        }

        private async Task<Item> UpdateItemAsync(IItem item)
        {
            if (item == null) return null;

            var idb = await Context.ItemSet.FindAsync(item.Nom);
            idb.Nom = item.Nom;
            idb.Qte = item.Qte;
            Context.Entry(idb).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return idb;
        }

        private async Task<Personnage> UpdatePersonnage(IPersonnage perso)
        {
            try
            {
                if (perso == null) return null;

                var pdb = await Context.PersonnageSet.FindAsync(perso.Nom);
                pdb.Nom = perso.Nom;
                pdb.Level = perso.Level;
                pdb.ArmeEquipe = perso.ArmeEquipe;
                pdb.ArmureEquipe = perso.ArmureEquipe;
                pdb.Classe = perso.Classe;
                pdb.Po = perso.Po;
                pdb.XpEnCours = perso.XpEnCours;
                pdb.XpMax = perso.XpMax;
                Context.Entry(pdb).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return pdb;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> RemoveAsync<T>(T item) where T : class
        {
            using (UseInMemory ? null : InitJdrDBEntities())
            {
                if (item == null) return false;
                bool result = false;
                using (var transaction = await Context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (typeof(T) == typeof(IPersonnage))
                        {
                            result = await RemovePersonnageAsync((IPersonnage)item);
                        }
                        else if (typeof(T) == typeof(IItem))
                        {
                            result = await RemoveItem((IItem)item);
                        }
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
                return result;
            }
        }

        private async Task<bool> RemoveItem(IItem item)
        {
            if (item == null) return false;

            var idb = await Context.ItemSet.FindAsync(item.Nom);

            DetachUnchangedEntites();
            var result = Context.ItemSet.Remove(idb).Entity;
            await Context.SaveChangesAsync();

            return result != null;
        }

        private void DetachUnchangedEntites()
        {
            var list = Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Unchanged).ToList();
            foreach (var entry in list)
                entry.State = EntityState.Detached;
        }

        private async Task<bool> RemovePersonnageAsync(IPersonnage perso)
        {
            if (perso == null) return false;

            var pdb = await Context.PersonnageSet.FindAsync(perso.Nom);

            DetachUnchangedEntites();
            var result = Context.PersonnageSet.Remove(pdb).Entity;
            await Context.SaveChangesAsync();

            return result != null;
        }
    }
}
