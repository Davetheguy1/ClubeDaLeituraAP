﻿using GestãoDeEquipamentosAP.Shared;
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

            boxes[amountOfBoxes++] = newBox;
        }

        public Box[] SelectBoxes()
        {
            return boxes;
        }

    }
}
