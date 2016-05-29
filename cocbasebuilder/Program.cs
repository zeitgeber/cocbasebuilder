using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cocbasebuilder.Model;
using cocbasebuilder.BaseGrabber.Interface;

namespace cocbasebuilder
{
    class Program
    {

        static void Main(string[] args)
        {
            //ExtendedBuilding townhall = new ExtendedBuilding("townhall", 4, 4, 1000, 0, 0, 1,6,4);
            //ExtendedBuilding cc = new ExtendedBuilding("cc", 3, 3, 1000, 8, 200, 1, 3, 4);
            //ExtendedBuilding king = new ExtendedBuilding("king", 3, 3, 1000, 8, 100, 1, 3, 4);
            //ExtendedBuilding air = new ExtendedBuilding("air", 3, 3, 1050, 10, 230, 3, 2, 4);
            //ExtendedBuilding tesla1 = new ExtendedBuilding("tesla", 2, 2, 770, 7, 75, 3, 2, 2);
            //ExtendedBuilding store = new ExtendedBuilding("store", 3, 3, 2100, 0, 0, 7, 1, 4);
            //ExtendedBuilding cannon1 = new ExtendedBuilding("cannon", 3, 3, 960, 9, 65, 5, 1, 4);
            //ExtendedBuilding archer1 = new ExtendedBuilding("archer", 3, 3, 810, 10, 65, 5, 1, 5);
            //ExtendedBuilding wizard1 = new ExtendedBuilding("wizard", 3, 3, 850, 7, 32, 3, 1, 4);
            //ExtendedBuilding mortar = new ExtendedBuilding("mortar", 3, 3, 650, 11, 9, 4, 1, 6);
            //ExtendedBuilding bomb = new ExtendedBuilding("bomb", 1, 1, 0, 3, 34, 6, 1, 4);
            //ExtendedBuilding giantbomb = new ExtendedBuilding("giantbomb", 2, 2, 0, 3, 225, 3, 1, 6);
            //ExtendedBuilding wall = new ExtendedBuilding("wall", 1, 1, 100, 5, 50, 50, 3, 1);

            Population pop = new Population(GlobalVar.PopulationSize);
            List<ExtendedBuilding> buildings = new List<ExtendedBuilding>();
            //ExtendedBuilding[] buildings = new ExtendedBuilding[GlobalVar.TotalBuildings] { townhall,archer1,
            //    cannon1,
            //tesla1,
            //wizard1,mortar,air,store,cc,king,bomb,giantbomb,wall
            //};
            //pop.AddBuilding(buildings);

            
            ////pop.DrawPopulation();
            //pop.ScorePopulation(buildings);
            //pop.GetBest(buildings);
            //for (int i = 0; i < GlobalVar.Generations && !Console.KeyAvailable && pop.ScorePopulation(buildings); i++)
            //{
            //    pop.ScorePopulation(buildings);
            //    //pop.GetBest();
            //    Console.Clear();
            //    pop.GetBest(buildings);
            //    Console.WriteLine("Generation: " + Convert.ToString(i));
            //    pop.Mutate(buildings);                
            //}
            
            //pop.ScorePopulation(buildings);
            //Console.Clear();
            //pop.DrawWalls(buildings);

            string url = "Builder#8fqtfEopEvA_hnwgAonBog_nvpnvw__nywjoj_ywknjv_wp_AssjjrrA_snrwnr_wm__ftDwvDIsvInI_ErsEIwzGrIbv_dzbm_hwrgEu_foBxif_nEqfGwgwcpdy_DpDqoEivouux_n2uBwoF_uyon_kdobsbwb_GkIo_EA_rr_aq_ihAizAhz_AekGfkhEgh_ws__uwpu_no_Hz-fo.y_gnoyz_hnz_inz_jnr.vz_knrvz_lnrvz_mnrvz_nnr.H_og.nrHI_pfgnrI_qfnrI_rfnr.EI_sfj.nrwAEI_tfjnrwAEI_ufjnrwAEI_vfjnrwA.EI_wfj.wAI_xfwAI_yfwAHI_zfgwA.H_Ag.wA_BoswA_CoswA_DoswA_Eops.wA_FoA_GoA_HozA_Io.z...i224-i4_i4_f2__l2_l2_c_f3_e2_b__l5_l5_dd_d2_c2_e5_b5_d3_bb_j3_cc_d_h_f_g3_b4_d__bb_d_b-a17";
            IBaseGrabber bg = new BaseGrabber.coctools.BaseGrabber(url);
            var actualResult = bg.ParseData();
            //"cannon,archer,air,xbow,goldstorage,elixerstorage,delixerstorage,mortar,wizard,herobarbarian,heroarcher,gold,elixer,delixer,tesla,bigbomb,bomb,spring,airbomb,airmine,barracks,dbarracks,spells,townhall,research,army,builder,castle,inferno,skeleton,airsweeper,darkspells,herowarden,eagle".Split(',');
            foreach (var b in actualResult)
            {
                switch (b.Name )
                {
                    case "cannon": buildings.Add(new ExtendedBuilding("cannon", 3, 3, 960, 9, 65, 1, 4, b.Top, b.Left));
                        break;
                    case "archer": buildings.Add(new ExtendedBuilding("archer", 3, 3, 810, 10, 65, 1, 5, b.Top, b.Left));
                        break;
                    case "air": buildings.Add(new ExtendedBuilding("air", 3, 3, 1050, 10, 230, 2, 4, b.Top, b.Left));
                        break;
                    case "xbow": buildings.Add(new ExtendedBuilding("archer", 3, 3, 810, 10, 65, 1, 5, b.Top, b.Left));
                        break;
                    case "goldstorage": buildings.Add(new ExtendedBuilding("store", 3, 3, 2100, 0, 0, 1, 4, b.Top, b.Left));
                        break;
                    case "elixerstorage": buildings.Add(new ExtendedBuilding("store", 3, 3, 2100, 0, 0, 1, 4, b.Top, b.Left));
                        break;
                    case "delixerstorage": buildings.Add(new ExtendedBuilding("store", 3, 3, 2100, 0, 0, 1, 4, b.Top, b.Left));
                        break;
                    case "mortar": buildings.Add(new ExtendedBuilding("mortar", 3, 3, 650, 11, 9, 1, 6, b.Top, b.Left));
                        break;
                    case "wizard": buildings.Add(new ExtendedBuilding("wizard", 3, 3, 850, 7, 32, 1, 4, b.Top, b.Left));
                        break;
                    case "herobarbarian": buildings.Add(new ExtendedBuilding("king", 3, 3, 1000, 8, 100, 3, 4, b.Top, b.Left));
                        break;
                    case "heroarcher": buildings.Add(new ExtendedBuilding("king", 3, 3, 1000, 8, 100, 3, 4, b.Top, b.Left));
                        break;
                    //case "gold": buildings.Add(archer1);
                    //    break;
                    //case "elixer": buildings.Add(archer1);
                    //    break;
                    //case "delixer": buildings.Add(archer1);
                    //    break;
                    case "tesla": buildings.Add(new ExtendedBuilding("tesla", 2, 2, 770, 7, 75, 2, 2, b.Top, b.Left));
                        break;
                    case "bigbomb": buildings.Add(new ExtendedBuilding("giantbomb", 2, 2, 0, 3, 225, 1, 6, b.Top, b.Left));
                        break;
                    case "bomb": buildings.Add(new ExtendedBuilding("bomb", 1, 1, 0, 3, 34, 1, 4, b.Top, b.Left));
                        break;
                    //case "spring": buildings.Add(archer1);
                    //    break;
                    case "airbomb": buildings.Add(new ExtendedBuilding("bomb", 1, 1, 0, 3, 34, 1, 4, b.Top, b.Left));
                        break;
                    case "airmine": buildings.Add(new ExtendedBuilding("bomb", 1, 1, 0, 3, 34, 1, 4, b.Top, b.Left));
                        break;
                    //case "barracks": buildings.Add(archer1);
                    //    break;
                    //case "dbarracks": buildings.Add(archer1);
                    //    break;
                    //case "spells": buildings.Add(archer1);
                    //    break;
                    case "townhall": buildings.Add(new ExtendedBuilding("townhall", 4, 4, 1000, 0, 0,6,4, b.Top, b.Left));
                        break;
                    //case "research": buildings.Add(archer1);
                    //    break;
                    //case "army": buildings.Add(archer1);
                    //    break;
                    //case "builder": buildings.Add(archer1);
                    //    break;
                    case "castle": buildings.Add(new ExtendedBuilding("cc", 3, 3, 1000, 8, 200, 3, 4, b.Top, b.Left));
                        break;
                    case "inferno": buildings.Add(new ExtendedBuilding("archer", 3, 3, 810, 10, 65, 1, 5, b.Top, b.Left));
                        break;
                    case "skeleton": buildings.Add(new ExtendedBuilding("bomb", 1, 1, 0, 3, 34, 1, 4, b.Top, b.Left));
                        break;
                    //case "airsweeper": buildings.Add(archer1);
                    //    break;
                    //case "darkspells": buildings.Add(archer1);
                    //    break;
                    case "herowarden": buildings.Add(new ExtendedBuilding("king", 3, 3, 1000, 8, 100, 3, 4, b.Top, b.Left));
                        break;
                    case "eagle": buildings.Add(new ExtendedBuilding("archer", 3, 3, 810, 10, 65, 1, 5, b.Top, b.Left));
                        break;
                    default: break;
                }
            }
            
            foreach (ExtendedBuilding b in buildings)
            {
                b.PrintDetails();
            }
            pop.AddBuilding(buildings);
            pop.ScorePopulation(buildings);
            pop.GetBest(buildings);
            Console.ReadLine();
        }
    }
}
