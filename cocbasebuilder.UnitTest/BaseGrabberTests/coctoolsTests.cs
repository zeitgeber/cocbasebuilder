using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cocbasebuilder.BaseGrabber;
using cocbasebuilder.BaseGrabber.Interface;
using cocbasebuilder.Model;
using System.Collections.Generic;

namespace cocbasebuilder.UnitTest.BaseGrabberTests
{
    [TestClass]
    public class coctoolsTests
    {
        [TestMethod]
        public void TestSmallBase()
        {
            string url = "Builder#8fqtfEopEvA_hnwgAonBog_nvpnvw__nywjoj_ywknjv_wp_AssjjrrA_snrwnr_wm__ftDwvDIsvInI_ErsEIwzGrIbv_dzbm_hwrgEu_foBxif_nEqfGwgwcpdy_DpDqoEivouux_n2uBwoF_uyon_kdobsbwb_GkIo_EA_rr_aq_ihAizAhz_AekGfkhEgh_ws__uwpu_no_Hz-fo.y_gnoyz_hnz_inz_jnr.vz_knrvz_lnrvz_mnrvz_nnr.H_og.nrHI_pfgnrI_qfnrI_rfnr.EI_sfj.nrwAEI_tfjnrwAEI_ufjnrwAEI_vfjnrwA.EI_wfj.wAI_xfwAI_yfwAHI_zfgwA.H_Ag.wA_BoswA_CoswA_DoswA_Eops.wA_FoA_GoA_HozA_Io.z...i224-i4_i4_f2__l2_l2_c_f3_e2_b__l5_l5_dd_d2_c2_e5_b5_d3_bb_j3_cc_d_h_f_g3_b4_d__bb_d_b-a17";
            List<Building> expectedResult = new List<Building>();
            #region prepare result
            expectedResult.Add(new Building
            {
                Damage = 0,
                Health = 0,
                Height = 0,
                Left = 1,
                MaxRange = 0,
                MinRange = 0,
                Name = "cannon",
                Top = 1,
                Width = 0
            });

            #endregion

            IBaseGrabber bg = new BaseGrabber.coctools.BaseGrabber(url);
            var actualResult = bg.ParseData();

            CollectionAssert.AreEqual(expectedResult, actualResult);
            
        }

    }
}
