using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TASKTI.Models;

namespace TASKTI.DAL
{
    public class TamuDAL : IDisposable
    {
        private TamuModelss db = new TamuModelss();

        public IQueryable<Tamu> GetData()
        {
            var result = from b in db.Tamu
                         //where b.username 
                         orderby b.Id_Tamu ascending
                         select b;
            return result;
        }

        //cek apakah barang dengan user yang sama ada di daftar tamu
        public Tamu GetByUser(string username)
        {
            var result = (from s in db.Tamu
                          where s.email == username 
                          select s).FirstOrDefault();

            return result;
        }


        public void TambahTamu(Tamu tmbh)
        {
            db.Tamu.Add(tmbh);
            db.SaveChanges();
        }

        public Tamu GetItemByID(int id)
        {
            var result = (from s in db.Tamu
                          where s.Id_Tamu == id
                          select s).SingleOrDefault();
            return result;
        }

        public void Delete(int id)
        {
            var hapus = GetItemByID(id);
            if (hapus != null)
            {
                try
                {
                    db.Tamu.Remove(hapus);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
            else
            {
                throw new Exception("Data tidak dapat dihapus !");
            }
        }

        public void Edit(Tamu obj)
        {
            var ubah = GetItemByID(obj.Id_Tamu);

            if (ubah != null)
            {
                ubah.email = obj.email;
                ubah.Nama_Tamu = obj.Nama_Tamu;
                ubah.Alamat = obj.Alamat;
                ubah.Ucapan_Selamat = obj.Ucapan_Selamat;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Data tidak dapat diubah !");
            }
        }

        //public IQueryable<BukuTamu> Search(string txtSearch)
        //{
        //    var result = from a in db.BukuTamu
        //                 where a.Nama_Tamu.ToLower().Contains(txtSearch.ToLower())
        //                 select a;
        //    return result;
        //}

        public void Dispose()
        {
            db.Dispose();
        }
    }
}