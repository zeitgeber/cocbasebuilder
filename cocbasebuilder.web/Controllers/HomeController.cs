using cocbasebuilder.BaseGrabber.Interface;
using cocbasebuilder.Model;
using cocbasebuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cocdb;

namespace cocbasebuilder.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RankMyBase(string url)
        {
            Population pop = new Population(1);
            List<ExtendedBuilding> buildings = new List<ExtendedBuilding>();
            
            //http://www.clashofclans-tools.com/Layout-Builder#8fqtfEopEvA_hnwgAonBog_nvpnvw__nywjoj_ywknjv_wp_AssjjrrA_snrwnr_wm__ftDwvDIsvInI_ErsEIwzGrIbv_dzbm_hwrgEu_foBxif_nEqfGwgwcpdy_DpDqoEivouux_n2uBwoF_uyon_kdobsbwb_GkIo_EA_rr_aq_ihAizAhz_AekGfkhEgh_ws__uwpu_no_Hz-fo.y_gnoyz_hnz_inz_jnr.vz_knrvz_lnrvz_mnrvz_nnr.H_og.nrHI_pfgnrI_qfnrI_rfnr.EI_sfj.nrwAEI_tfjnrwAEI_ufjnrwAEI_vfjnrwA.EI_wfj.wAI_xfwAI_yfwAHI_zfgwA.H_Ag.wA_BoswA_CoswA_DoswA_Eops.wA_FoA_GoA_HozA_Io.z...i224-i4_i4_f2__l2_l2_c_f3_e2_b__l5_l5_dd_d2_c2_e5_b5_d3_bb_j3_cc_d_h_f_g3_b4_d__bb_d_b-a17
            //string url = "Builder#8fqtfEopEvA_hnwgAonBog_nvpnvw__nywjoj_ywknjv_wp_AssjjrrA_snrwnr_wm__ftDwvDIsvInI_ErsEIwzGrIbv_dzbm_hwrgEu_foBxif_nEqfGwgwcpdy_DpDqoEivouux_n2uBwoF_uyon_kdobsbwb_GkIo_EA_rr_aq_ihAizAhz_AekGfkhEgh_ws__uwpu_no_Hz-fo.y_gnoyz_hnz_inz_jnr.vz_knrvz_lnrvz_mnrvz_nnr.H_og.nrHI_pfgnrI_qfnrI_rfnr.EI_sfj.nrwAEI_tfjnrwAEI_ufjnrwAEI_vfjnrwA.EI_wfj.wAI_xfwAI_yfwAHI_zfgwA.H_Ag.wA_BoswA_CoswA_DoswA_Eops.wA_FoA_GoA_HozA_Io.z...i224-i4_i4_f2__l2_l2_c_f3_e2_b__l5_l5_dd_d2_c2_e5_b5_d3_bb_j3_cc_d_h_f_g3_b4_d__bb_d_b-a17";
            //string url = "Builder#8cAlJryhruI_gAoJdxlCpC_jynGru__bEyIhn_hKdnyE_sq_gxqFvzmq_nudruE_dI__zAzxzrzoumrm_AkCnajCKlmjj_vqvu_eElGiI_fvrIhv_vCxClslqwClr_btuMgtgruHwH_pFlxltuC_fGhI_gjdjomzu_CHxl_FE_gE_Cq_mhCzCurh_paMaMMaaMy_ny__eGhJ_jw_CE-bx.CE.O_cv.ENO_dn.vEO_envEO_fnvEO_gnvEO_hnvEO_invEO_jnvEO_knvEO_ln.vC.O_mqvCGN_nqu.CGNO_oquyCGNO_pquyC.GNO_qquyCNO_rqu.CNO_sq.uyCNO_tquyCN_uquyC.N_vqu.CEM_wqzEM_xqzEM_yqzEM_zq.EM_AEM_BEM_CE.M...i224-k4_k4_g2__l2_l2_e_g3_g2_b__m5_m5_dd_g2_d2_f5_b5_d3_bb_k3_ee_d_i_g_g3_b4_e__cc_e_c-a17";
            url.Replace("http://www.clashofclans-tools.com/Layout-", "");
            IBaseGrabber bg = new BaseGrabber.coctools.BaseGrabber(url);
            var actualResult = bg.ParseData();
            foreach (var b in actualResult)
            {
                switch (b.Name)
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
                    case "townhall": buildings.Add(new ExtendedBuilding("townhall", 4, 4, 1000, 0, 0, 6, 4, b.Top, b.Left));
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
            pop.AddBuilding(buildings);
            pop.ScorePopulation(buildings);
            var score = pop.GetBest(buildings);
            cocdb.cocdb db = new cocdb.cocdb();
            db.AddBase(url, score, 1);
            
            ViewBag.URL = HttpUtility.HtmlEncode(url??"");
            ViewBag.BaseScore = score;
            ViewBag.Top = db.GetTop10Bases();
            

            return View();
        }
    }
}