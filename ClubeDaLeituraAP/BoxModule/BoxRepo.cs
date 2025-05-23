﻿using ClubeDaLeituraAP.MagazineModule;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.BoxModule
{
    public class BoxRepo
    {
        public Box[] boxes = new Box[100];
        public int amountOfBoxes = 0;

        public void RegisterBox(Box newBox)
        {
            newBox.Id = IdGenerator.GenerateBoxID();
            newBox.magazines = new Magazine[100]; 

            boxes[amountOfBoxes++] = newBox;
        }

       
        public bool EditBox(int selectedId, Box editedBox)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i] == null)
                    continue;

                else if (boxes[i].Id == selectedId)
                {
                    boxes[i].Tag = editedBox.Tag;
                    boxes[i].Colour = editedBox.Colour;
                    boxes[i].MaxBorrowDays = editedBox.MaxBorrowDays;

                    return true;

                }

            }
            return false;
        }

        public bool DeleteBox(int selectedId)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i] == null) continue;

                else if (boxes[i].Id == selectedId)
                {
                    if (boxes[i].magazines.Length > 0)
                    {
                        Console.WriteLine("Não é possivel deletar uma caixa que ainda contém revistas.");
                        return false;
                    }
                    
                    
                    boxes[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Box[] SelectBoxes()
        {
            return boxes;
        }

    }
}
