using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.MagazineModule;
using ClubeDaLeituraAP.UserModule;
using GestãoDeEquipamentosAP.Shared;

namespace ClubeDaLeituraAP.BorrowModule
{
    public class BorrowRepo
    {
        MagazineRepo magazineRepo;
        UserRepo userRepo;
        
        public Borrow[] borrows = new Borrow[100];
        public int amountOfBorrows = 0;

        public void RegisterBorrow(Borrow newBorrow)
        {
            newBorrow.Id = IdGenerator.GenerateBorrowId();

            borrows[amountOfBorrows++] = newBorrow;
        }

        public bool EditBorrow(int selectedId, Borrow editeBorrow)
        {
            for (int i = 0; i < borrows.Length; i++)
            {
                if (borrows[i] == null) continue;

                else if (borrows[i].Id == selectedId)
                {
                    borrows[i].User = editeBorrow.User;
                    borrows[i].Magazine = editeBorrow.Magazine;
                    borrows[i].MaxBorrowDays = editeBorrow.MaxBorrowDays;

                    return true;
                }

            } return false;
            }

        public bool DeleteBorrow(int selectedId)
        {
            for (int i = 0;i < borrows.Length; i++)
            {
                if (borrows[i] == null) continue;

                else if (borrows[i].Id == selectedId)
                {
                    borrows[i] = null;
                    return true;    
                }
            } return false;
        }

        public Borrow[] SelectBorrows()
        {
            return borrows;
        }

        public string GetMagId(int magazineId)
        {
            for(int i = 0; i < magazineRepo.magazines.Length; i++)
            {
                if (magazineRepo.magazines[i] == null)
                {
                    continue;
                }

                else if (magazineRepo.magazines[i].Id == magazineId)
                {
                    magazineRepo.magazines[i].CurrentStatus = "Alugada";
                    return magazineRepo.magazines[i].Title;
                }
            } return "Erro";
        }

        public string GetUserId(int userId)
        {
            for (int i = 0; i < userRepo.users.Length; i++)
            {
                if (userRepo.users[i] == null)
                {
                    continue;
                }

                else if (userRepo.users[i].Id == userId)
                {
                    
                    return userRepo.users[i].Name;
                }
            }
            return "Erro";
        }

        public int GetBorrowDays(int magazineId)
        {
            for (int i = 0; i < magazineRepo.magazines.Length; i++)
            {
                if (magazineRepo.magazines[i] == null)
                {
                    continue;
                }

                else if (magazineRepo.magazines[i].Id == magazineId)
                {
                    return magazineRepo.magazines[i].MaxBorrowDays;


                }
            } return 7;
            
        }



    }
}
