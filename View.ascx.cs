/*
' Copyright (c) 2013  Innovaction.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using Innovaction.Modules.CustomerCreate.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using System.Web.UI;
using Innovaction;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace Innovaction.Modules.CustomerCreate
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from UpdateCustomerModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : CustomerCreateModuleBase, IActionable
    {

   
     

        protected void Page_Load(object sender, EventArgs e)
        {

            DotNetNuke.Framework.jQuery.RequestDnnPluginsRegistration();

            if (!IsPostBack)
            {

             

                PopulateDropdowns();




            }
        }

        protected void rptItemListOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;


                var pnlAdminControls = e.Item.FindControl("pnlAdmin") as Panel;

                var t = (Item)e.Item.DataItem;

                if (IsEditable && lnkDelete != null && lnkEdit != null && pnlAdminControls != null)
                {
                    pnlAdminControls.Visible = true;
                    lnkDelete.CommandArgument = t.ItemId.ToString();
                    lnkDelete.Enabled = lnkDelete.Visible = lnkEdit.Enabled = lnkEdit.Visible = true;

                    lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, "Edit", "tid=" + t.ItemId);

                    ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile));
                }
                else
                {
                    pnlAdminControls.Visible = false;
                }
            }
        }

        public void rptItemListOnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "tid=" + e.CommandArgument));
            }

            if (e.CommandName == "Delete")
            {
                var tc = new ItemController();
                tc.DeleteItem(Convert.ToInt32(e.CommandArgument), ModuleId);
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        private void PopulateDropdowns()
        {

            // nacionalidad
            dd_Country.DataSource = Innovaction.WSManager.GetCountries();
            dd_Country.DataValueField = "VALUE";
            dd_Country.DataTextField = "TEXT";
            dd_Country.DataBind();

            // estados
            dd_State.DataSource = Innovaction.WSManager.GetState(PortalId);
            dd_State.DataValueField = "VALUE";
            dd_State.DataTextField = "TEXT";
            dd_State.DataBind();

            // cuidades

            dd_City.DataSource = Innovaction.WSManager.GetCity(dd_State.SelectedValue);
            dd_City.DataValueField = "VALUE";
            dd_City.DataTextField = "TEXT";
            dd_City.DataBind();

            // matrial state
            //dd_MatrialState.DataSource = Innovaction.WSManager.GetMatrialStatus();
            //dd_MatrialState.DataValueField = "VALUE";
            //dd_MatrialState.DataTextField = "TEXT";
            //dd_MatrialState.DataBind();

            // address types
            //dd_Address.DataSource = Innovaction.WSManager.GetAddressTypes();
            //dd_Address.DataValueField = "VALUE";
            //dd_Address.DataTextField = "TEXT";
            //dd_Address.DataBind();

            // jobs ocupaciones
            //dd_Jobs.DataSource = Innovaction.WSManager.GetOccupations();
            //dd_Jobs.DataValueField = "VALUE";
            //dd_Jobs.DataTextField = "TEXT";
            //dd_Jobs.DataBind();


            // topics

            chbx_Topics.DataSource = Innovaction.WSManager.GetCommunicationTopic();
            chbx_Topics.DataValueField = "VALUE";
            chbx_Topics.DataTextField = "TEXT";
            chbx_Topics.DataBind();
            // set all to true!
            foreach (ListItem TheItem in chbx_Topics.Items){TheItem.Selected = true;}
            // frequency

            rb_Frequency.DataSource = Innovaction.WSManager.GetCommunicationFrequencies();
            rb_Frequency.DataValueField = "VALUE";
            rb_Frequency.DataTextField = "TEXT";
            rb_Frequency.DataBind();
            rb_Frequency.Items[0].Selected = true;

            // channel

            rb_Channel.DataSource = Innovaction.WSManager.GetCommunicationChannels();
            rb_Channel.DataValueField = "VALUE";
            rb_Channel.DataTextField = "TEXT";
            rb_Channel.DataBind();
            foreach (ListItem TheItem in rb_Channel.Items){TheItem.Selected = true;}

        }

        private List<ChildrenControl> GetChildControlList()
        {
            var ToReturn = new List<ChildrenControl>();

            foreach (ChildrenControl elControl in Kid_DynamicAddControl.ChildControlList)
            {

                //trabajo todos los controles menos los que se usaron para "testear"
                if (((elControl.Visible == true) && (elControl.IsNew)) || ((elControl.Visible == false) && (!elControl.IsNew)))
                {

                    ToReturn.Add(elControl);
                }


            }


            return ToReturn;

        }

        protected void dd_State_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dd_State.SelectedValue != "-1")
            {
                dd_City.DataSource = Innovaction.WSManager.GetCity(dd_State.SelectedValue);
                dd_City.DataBind();
            }
        }

     


        bool DoRegisterOrUpdate(bool IsUpdate, bool RequiresPopup = true) {
           
    
            var ToUpdate = Innovaction.WSManager.EmptyCustomer(PortalId);

            #region datos personales
            ToUpdate.fistName = tx_FirstName.Text;
            ToUpdate.lastName = tx_FirstSurname.Text;

            ToUpdate.gender = dd_Gender.SelectedValue;
            ToUpdate.birthDay = dd_BirthDate.SelectedValue;
            ToUpdate.birthDaySpecified = true;
            ToUpdate.nickname = tx_Email.Text;


            // ci
            ToUpdate.nationalId = tx_CI.Text;
         
            if((!String.IsNullOrEmpty(tx_CustomerID.Text)) && (IsUpdate)){
                try
                {
                    ToUpdate.id = Convert.ToInt32(tx_CustomerID.Text);
                }
                catch { }
            ToUpdate.idSpecified = true;
            }
            //else
            //{
            //    ToUpdate.id = Convert.ToInt32(tx_CustomerID.Text);
            //}
           
            ToUpdate.password = tx_Password.Text;

            // celular
            if (!String.IsNullOrEmpty(tx_CellPhone.Text))
            {
            ToUpdate.phone = new Innovaction.CustomerDataWS.phoneTo[1];
            var Phone = new Innovaction.CustomerDataWS.phoneTo();
            ToUpdate.phone[0] = Phone;
            Phone.numberNew = tx_CellPhone.Text;
            Phone.phoneType = new Innovaction.CustomerDataWS.phoneTypeTo();
            Phone.phoneType.id = "MOBILE";
            if (IsUpdate)
            {
                Phone.operationType = Innovaction.CustomerDataWS.operationType.UPDATE;
            }
            else {
                Phone.operationType = Innovaction.CustomerDataWS.operationType.INSERT;
            }
            Phone.operationTypeSpecified = true;
            Phone.primary = true;
            }


            #endregion

            if(IsUpdate){
            // en realidad es un update mentiroso, por que nada de esta informacion existe..


            #region direccion

                // aparentemente tenemos que borrar las direcciones
                ToUpdate.address = new Innovaction.CustomerDataWS.addressTo[2];
                // borro el viejo


                //int atmpIndex = 0;
                //foreach (ListItem addtype in dd_Address.Items)
                //{
                //    if (!addtype.Selected)
                //    {
                var AddressToDelete = new Innovaction.CustomerDataWS.addressTo();
                AddressToDelete.operationType = Innovaction.CustomerDataWS.operationType.DELETE;
                AddressToDelete.operationTypeSpecified = true;
                AddressToDelete.addressType = new Innovaction.CustomerDataWS.addressTypeTo();
                AddressToDelete.addressType.id = "HOME";
                AddressToDelete.city = new Innovaction.CustomerDataWS.cityTo();
                AddressToDelete.city.id = dd_City.SelectedValue;
                AddressToDelete.city.state = new Innovaction.CustomerDataWS.stateTo();
                AddressToDelete.city.state.id = dd_State.SelectedValue;
                // portal id
                AddressToDelete.city.state.country = new Innovaction.CustomerDataWS.countryTo();
                AddressToDelete.city.state.country.id = Innovaction.WSManager.CountryID(PortalId);
                ToUpdate.address[0] = AddressToDelete;

                //        atmpIndex++;
                //    }

                //}


                // finalmente insertamos la nuestra
                var Address = new Innovaction.CustomerDataWS.addressTo();
                Address.operationTypeSpecified = true;
                Address.primary = true;
                Address.operationType = Innovaction.CustomerDataWS.operationType.UPDATE;

                Address.addressType = new Innovaction.CustomerDataWS.addressTypeTo();
                Address.addressType.id = "HOME";

                var Ciudad = new Innovaction.CustomerDataWS.cityTo();
                Ciudad.id = dd_City.SelectedValue;
                var State = new Innovaction.CustomerDataWS.stateTo();
                State.id = dd_State.SelectedValue;
                var Country = new Innovaction.CustomerDataWS.countryTo();
                // portal id
                Country.id = Innovaction.WSManager.CountryID(PortalId);
                State.country = Country;
                Ciudad.state = State;
                Address.city = Ciudad;
                
                ToUpdate.address[1] = Address;


            #endregion

            #region otros datos
            ToUpdate.nationality = new Innovaction.CustomerDataWS.countryTo();
            ToUpdate.nationality.id = dd_Country.SelectedValue;


            //ToUpdate.occupation = new Innovaction.CustomerDataWS.occupationTo();
            //ToUpdate.occupation.id = dd_Jobs.SelectedValue;

            //ToUpdate.childQty = Kid_DynamicAddControl.ChildControlList.Count;
            //ToUpdate.childQtySpecified = true;
            var ControlList = GetChildControlList();
            ToUpdate.children = new Innovaction.CustomerDataWS.customerChildTo[ControlList.Count];
            int tmpChild = 0;
            foreach (ChildrenControl elControl in ControlList)
            {

                //leo la info de cada control
                ToUpdate.children[tmpChild] = new Innovaction.CustomerDataWS.customerChildTo();
                var Child = ToUpdate.children[tmpChild];
                Child.customerChildNoSpecified = true;


                if ((elControl.Visible == false) && (!elControl.IsNew))
                {
                    Child.operationType = Innovaction.CustomerDataWS.operationType.DELETE;
                    Child.customerChildNo = elControl.SelectedKid;
                }
                else if (elControl.IsNew)
                {
                    Child.customerChildNo = tmpChild;
                    Child.operationType = Innovaction.CustomerDataWS.operationType.INSERT;
                }

                Child.operationTypeSpecified = true;



                Child.birthDateSpecified = true;
                ToUpdate.children[tmpChild].birthDate = elControl.SelectedDate;


                if (elControl.SelectedGender == "F")
                {
                    ToUpdate.children[tmpChild].gender = Innovaction.CustomerDataWS.gender.F;
                }
                else
                {
                    ToUpdate.children[tmpChild].gender = Innovaction.CustomerDataWS.gender.M;
                }

                ToUpdate.children[tmpChild].genderSpecified = true;


                //  elControl.SelectedGender;
                tmpChild++;

            }


            #endregion

            }
            #region preferencias de envio
            // siempre vamos a mandarle las preferencias de envio, queremos que el default sea todo prendido


            ToUpdate.communicationAllowanceSpecified = true;
            //var AllowPreferences = Convert.ToBoolean(rb_info.SelectedValue);
            //ToUpdate.communicationAllowance = AllowPreferences;
            // preferences
            // topics!
            ToUpdate.communicationPreference = new CustomerDataWS.communicationPreferenceTo();
            if (chbx_Topics.Items.Count > 0)
            {
                ToUpdate.communicationPreference.topics = new Innovaction.CustomerDataWS.topicTo[chbx_Topics.Items.Count];


                int tmpIndex = 0;
                foreach (ListItem TheTopic in chbx_Topics.Items)
                {

                    var Topic = new Innovaction.CustomerDataWS.topicTo();
                    Topic.id = TheTopic.Value;
                    Topic.active = TheTopic.Selected;
                    Topic.operationTypeSpecified = true;
                    if (TheTopic.Selected)
                    {
                        Topic.operationType = Innovaction.CustomerDataWS.operationType.INSERT;
                    }
                    else
                    {
                        Topic.operationType = Innovaction.CustomerDataWS.operationType.DELETE;
                    }
                    ToUpdate.communicationPreference.topics[tmpIndex] = Topic;
                    tmpIndex++;
                }
            }
            //fequency
            // tengo que recorrerlos 1 por 1 por que los tienen en un valor de array separado si uso insert.. tengo q borrar y insertar el nuevo
            ToUpdate.communicationPreference.frequencies = new Innovaction.CustomerDataWS.frequencyTo[rb_Frequency.Items.Count];
            int tmpFCount = 0;
            foreach (ListItem TheFrequency in rb_Frequency.Items)
            {
                var Frequency = new Innovaction.CustomerDataWS.frequencyTo();
                Frequency.id = TheFrequency.Value;
                if (TheFrequency.Selected)
                {
                    Frequency.operationType = Innovaction.CustomerDataWS.operationType.INSERT;
                }
                else
                {
                    Frequency.operationType = Innovaction.CustomerDataWS.operationType.DELETE;
                }
                Frequency.operationTypeSpecified = true;
                Frequency.active = true;


                ToUpdate.communicationPreference.frequencies[tmpFCount] = Frequency;
                tmpFCount++;
            }

            // channel
            // mismo caso que la frequency..

            ToUpdate.communicationPreference.channels = new Innovaction.CustomerDataWS.channelTo[rb_Channel.Items.Count];
            int tmpCounter = 0;
            foreach (ListItem TheChannel in rb_Channel.Items)
            {

                var Channel = new Innovaction.CustomerDataWS.channelTo();
                Channel.id = TheChannel.Value;
                if (TheChannel.Selected)
                {
                    Channel.operationType = Innovaction.CustomerDataWS.operationType.INSERT;
                }
                else
                {
                    Channel.operationType = Innovaction.CustomerDataWS.operationType.DELETE;
                }
                Channel.operationTypeSpecified = true;
                Channel.active = true;


                ToUpdate.communicationPreference.channels[tmpCounter] = Channel;
                tmpCounter++;
            }

            #endregion




            // we update the customer
            var respuesta = new Innovaction.CustomerDataWS.customerResponse();
            if (IsUpdate)
            {
                respuesta = Innovaction.WSManager.UpdateCustomer(ToUpdate, PortalId);

               
                if (respuesta.responseCode == CustomerDataWS.responseCode.SUCCESS)
                {

                    if (RequiresPopup){DnnAlert( "Muchas gracias, sus datos han sido actualizados." , 300);}
                    return true;

                }
                else
                {
                    if (RequiresPopup) { DnnAlert("Error al actualizar el usuario: " + respuesta.responseMessage, 300); }
                    return false;
                 
                }
                }        
                // la primera vez guardamos, no es un update!
            else{
                respuesta = Innovaction.WSManager.CreateCustomer(ToUpdate, PortalId);
               
                    if (respuesta.responseCode == CustomerDataWS.responseCode.SUCCESS)
                    {
                        if (RequiresPopup){DnnAlert("Muchas gracias por registrarte, te invitamos a llenar algunos datos adicionales para conocerte un poco más.", 400);}
                        
                        tx_CustomerID.Text = respuesta.customer.id.ToString();
                        return true;
                    }
                    else
                    {
                        if (RequiresPopup){ DnnAlert("Error al crear el usuario: " + respuesta.responseMessage, 300); }

                        return false;
                    
                }

               

            }

           
            // response output debugg.

        }


        // este metodo estaria bueno mandarlo a alguna dll innovaction
        void DnnAlert(string Text, int Width) {
            string jquery = @"jQuery(function ($) {
        
            $.dnnAlert({ 
                text: '" + Text + @"',
                width: " + Width + @"
                        });
                                        });";

         DotNetNuke.UI.Utilities.ClientAPI.RegisterStartUpScript(
            Page, "", "<script type=\"text/javascript\">" + jquery + "</script>");

        }

        protected void RegisterFirst_Click(object sender, EventArgs e)
        {

            // verificamos el captcha si es el primer registro
            if (!ctlCaptcha.IsValid)
            {
                //vamos a tirar el popup y terminar el metodo
                 return;
            }

            if (DoRegisterOrUpdate(false)) {
                CreateWizard.ActiveStepIndex = CreateWizard.ActiveStepIndex + 1;
            }

        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            if (DoRegisterOrUpdate(true, false)) {
                CreateWizard.ActiveStepIndex = CreateWizard.ActiveStepIndex + 1;
            }

        }


        protected void RegistrarButton_Click(object sender, WizardNavigationEventArgs e)
        {

            DoRegisterOrUpdate(true);

        }

    


    }
}