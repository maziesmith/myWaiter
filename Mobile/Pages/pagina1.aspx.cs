﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Controller;

namespace myWaiter
{
    public partial class pagina1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["conta"] != null && Session["idMesa"] != null)
            {
                if (Session["currentUser"] != null)
                {
                    int idMesa = Convert.ToInt32(HttpContext.Current.Session["idMesa"]);
                    if (Session["currentUser"].ToString() == "Mesa " + idMesa)
                    {
                        Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx");
                    }
                }
                else
                {
                    if (ControllerComanda.getCountComanda() >= 1)
                    {
                        Response.Redirect("~/Mobile/Pages/paginaComandas.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }  
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ControllerComanda.inserirComandaUnica();
            int idMesa = Convert.ToInt32(HttpContext.Current.Session["idMesa"]);
            Session["currentUser"] = "Mesa " + idMesa;
            Session["idCurrentUser"] = ControllerComanda.getIdComanda("Mesa " + idMesa);
            Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx");
        }
    }
}