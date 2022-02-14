using DAL;
using DAL.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutiveOperations.Controllers
{
    public class ExecutiveRepository
    {
        private ExecutiveContext _executiveContext = new ExecutiveContext();

        public void InsertResident(Resident resident)
        {
            try
            {
                _executiveContext.resident.Add(resident);
                _executiveContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogInsert(new Logger { Message = "Ekleme işlemi yapılırken hata meydana geldi." + ex.Message });
            }

        }
        public void CreateUser(User user)
        {
            try
            {
                _executiveContext.user.Add(user);
                _executiveContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogInsert(new Logger { Message = "Kullanıcı oluşturulurken hata meydana geldi." + ex.Message });
            }

        }
        public User GetAuthUser(User authUser)
        {
            User aPIAuthority = new User();
            if (!string.IsNullOrEmpty(authUser.UserName) && !string.IsNullOrEmpty(authUser.Password))
            {
                aPIAuthority = _executiveContext.user.FirstOrDefault(u => u.UserName == authUser.UserName && u.Password == authUser.Password);
            }
            return aPIAuthority;
        }
        public void UpdateResident(Resident resident)
        {
            try
            {
                Resident isResident = new Resident();
                isResident = ResidentSelectById(resident.Id);
                if (isResident != null)
                {
                    _executiveContext.resident.Update(resident);
                    _executiveContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogInsert(new Logger { Message = "Güncelleme işlemi yapılırken hata ile karşılaşıldı" + ex.Message });
            }
        }
        public void UpdateFlat(Flat flat)
        {
            try
            {
                Flat isFlat = new Flat();
                isFlat = FlatSelectById(flat.Id);
                if (isFlat != null)
                {
                    _executiveContext.flat.Update(flat);
                    _executiveContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogInsert(new Logger { Message = "Güncelleme işlemi yapılırken hata ile karşılaşıldı" + ex.Message });
            }
        }
        public Resident ResidentSelectById(int Id)
        {
            Resident resident = new Resident();
            resident = _executiveContext.resident.FirstOrDefault(u => u.Id == Id);
            return resident;
        }
        public Flat FlatSelectById(int Id)
        {
            Flat flat = new Flat();
            flat = _executiveContext.flat.FirstOrDefault(u => u.Id == Id);
            return flat;
        }

        public bool DeleteResident(int Id)
        {
            Resident movie = new Resident();
            movie = ResidentSelectById(Id);
            if (movie != null)
            {
                _executiveContext.resident.Remove(movie);
                _executiveContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteFlat(int Id)
        {
            Flat flat = new Flat();
            flat = FlatSelectById(Id);
            if (flat != null)
            {
                _executiveContext.flat.Remove(flat);
                _executiveContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Resident> SelectAllResidents()
        {

            List<Resident> residentList = new List<Resident>();
            residentList = _executiveContext.resident.ToList();
            return residentList;
        }
        public List<Flat> SelectAllFlats()
        {

            List<Flat> flatList = new List<Flat>();
            flatList = _executiveContext.flat.ToList();
            return flatList;
        }
        public void LogInsert(Logger logger)
        {
            try
            {
                _executiveContext.logger.Add(logger);
                _executiveContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

    }
}
