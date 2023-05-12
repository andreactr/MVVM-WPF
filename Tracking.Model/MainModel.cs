using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.ComponentModel;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tracking.Model
{
    public class MainModel
    {
        
        public List<Track> GetLeftTracking()
        {

            return new List<Track> {
            new Track{Check=false, Id= 1, Type= 1, Tracking= "T1"},
            new Track{Check=false, Id= 2, Type= 1, Tracking= "T2"},
            new Track{Check=false, Id= 3, Type= 1, Tracking= "T3"}
            }; 
        }
        public List<Track> GetRigthTracking()
        {

            return new List<Track> {
            new Track{Check = false,  Id= 4, Type= 1, Tracking= "T4"},
            new Track{Check = false,  Id= 5, Type= 1, Tracking= "T5"},
            new Track{Check = false,  Id= 6, Type= 1, Tracking= "T6"}
            };
        }


        //CONVERTIR ESTOS METODOS EN TASK
        public void Move(Track selected, ref List<Track> left, ref List<Track> right, MoveType option)
        {
            if (selected == null)
            throw new Exception("No hay filas seleccionadas");


            if (option == MoveType.LeftToRight)
            {
                left.Remove(selected);
                right.Add(selected);
                selected.Check = false; 

            }
            else if (option == MoveType.RightToLeft)
            {
                right.Remove(selected);
                left.Add(selected);
                selected.Check = false;
            }
        }

        public async Task<Results> MoveAsync(Track selected, List<Track> left, List<Track> right, MoveType option)
        {
            Thread.Sleep(9000);
            if (selected == null)
                throw new Exception("No hay filas seleccionadas");


            if (option == MoveType.LeftToRight)
            {
                left.Remove(selected);
                selected.Check = false;
                right.Add(selected);

            }
            else if (option == MoveType.RightToLeft)
            {
                right.Remove(selected);
                selected.Check = false;
                left.Add(selected);
            }

            Results results= new Results();
            results.LeftList = left;
            results.RightList= right;

            return results;
        }

        public void MoveMultiple(ref List<Track> left, ref List<Track> right, MoveType option)
        {
            
            if (option == MoveType.LeftToRight)
            {
                var newleft= left.Where(x => x.Check == true).ToList();
                if (newleft == null)
                    throw new Exception("No hay filas seleccionadas");
                foreach (var item in newleft)
                {
                    
                    if(item.Check == true) 
                    { 
                         left.Remove(item);
                         right.Add(item);
                        item.Check = false;
                    }                   
                }
            }
            else if (option == MoveType.RightToLeft)
            {
                var newright = right.Where(x => x.Check == true).ToList();
                if (newright == null)
                    throw new Exception("No hay filas seleccionadas");
                foreach (var item in newright)
                {
                    if (item.Check == true)
                    {
                        right.Remove(item);
                        left.Add(item);
                       item.Check = false;
                    }
                }
            }
        }
        public async Task<Results> MoveMultipleAsync(List<Track> left, List<Track> right, MoveType option)
        {
            Thread.Sleep(9000);
            if (option == MoveType.LeftToRight)
            {
                var newleft = left.Where(x => x.Check == true).ToList();
                if (newleft == null)
                    throw new Exception("No hay filas seleccionadas");
                foreach (var item in newleft)
                {

                    if (item.Check == true)
                    {
                        
                        left.Remove(item);
                        item.Check = false;
                        right.Add(item);
                    }
                }
            }
            else if (option == MoveType.RightToLeft)
            {
                var newright = right.Where(x => x.Check == true).ToList();
                if (newright == null)
                    throw new Exception("No hay filas seleccionadas");
                foreach (var item in newright)
                {
                    if (item.Check == true)
                    {
                        right.Remove(item);
                        item.Check = false;
                        left.Add(item);
                        
                    }
                }
            }
            Results results = new Results();
            results.LeftList = left;
            results.RightList = right;

            return results;
        }
    }

    public enum MoveType
    {
        LeftToRight,
        RightToLeft
    }
}
