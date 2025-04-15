using ClubeDaLeituraAP.BoxModule;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.MagazineModule
{
    public class MagazineRepo
    {
        public BoxRepo boxRepo;
        public Magazine[] magazines = new Magazine[100];
        public int amountOfMagazines = 0;

        public MagazineRepo(BoxRepo boxRepo)
        {
            this.boxRepo = boxRepo;
        }

        public void RegisterMagazine(Magazine newMagazine)
        {
            newMagazine.Id = IdGenerator.GenerateMagazine();

            magazines[amountOfMagazines++] = newMagazine;
        }
        
        public bool EditMagazine(int selectedId, Magazine editedMagazine)
        {
            for (int i = 0; i < magazines.Length; i++)
            {
                if (magazines[i] == null)
                    continue;

                else if (magazines[i].Id == selectedId)
                {
                    magazines[i].Title = editedMagazine.Title;
                    magazines[i].Edition = editedMagazine.Edition;
                    magazines[i].LaunchDate = editedMagazine.LaunchDate;
                    magazines[i].DesignatedBox = editedMagazine.DesignatedBox;

                    return true;

                }
            } return false;
        }

        public bool DeleteMagazine(int selectedId)
        {
            for (int i = 0; i < magazines.Length; i++)
            {
                if (magazines[i] == null) continue;

                else if (magazines[i].Id == selectedId)
                {
                    magazines[i] = null;
                    return true;
                }
            }
            return false;
        }
        
        public Magazine[] SelectMagazines()
        {
            return magazines;
        }
        
        
        public void AlocateMag(int boxId, Magazine magazine)
        {
            for (int i = 0; i < boxRepo.boxes[i].magazines.Length; i++)
            {
                if (boxRepo.boxes[i].Id == null)
                    continue;

                else if (boxRepo.boxes[i].Id == boxId)
                {
                    boxRepo.boxes[i].magazines[amountOfMagazines++] = magazine;
                    magazine.MaxBorrowDays = boxRepo.boxes[i].MaxBorrowDays;
                    magazine.DesignatedBox = boxRepo.boxes[i].Tag;
                    break;
                }
            }
        }
    
    
    
    
    }
}
