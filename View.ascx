<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Innovaction.Modules.CustomerCreate.View" %>
<%@ Register Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" TagPrefix="cc2" %>
<%@ Register Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" TagPrefix="cc1" %>
<%@ Register Src="DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>
<%@ Register Src="DynamicAddControl.ascx" TagPrefix="uc1" TagName="DynamicAddControl" %>



 

<script type="text/javascript">
    function MyAlert() {
        jQuery(function ($) {
            $('#dialogs-demo .alert').click(function (event) {
                event.preventDefault();
                $.dnnAlert({
                    text: 'Sus datos han sido actualizados.',
                    width: 300
                });
            });
        });
    }
</script>
    		


   
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
<!-- vamos a usar un div para cada tab-->
<div id="MainPanel" runat="server">


    
        <div class ="row">
           
            <div class="column twelve">

    <asp:Wizard ID="CreateWizard" runat="server" ActiveStepIndex="0" DisplaySideBar="False" Width="100%" CancelButtonType="Link" CancelButtonText="Cancelar  | " FinishCompleteButtonText="Registrar" FinishCompleteButtonType="Link" FinishPreviousButtonType="Link" FinishPreviousButtonText="Volver  | " StartNextButtonText="Siguiente" StartNextButtonType="Link" StepNextButtonText="Siguiente" StepNextButtonType="Link" StepPreviousButtonText="Volver  | " StepPreviousButtonType="Link" OnFinishButtonClick="RegistrarButton_Click">
        <NavigationStyle HorizontalAlign="Left" />
        <WizardSteps>

            <asp:WizardStep ID="WizardStep1" runat="server" Title="DatosPersonales">
                    <!-- TAB-->
    <!-- Datos personales tab-->
  
                  <div id="DatosPersonales"  >
          <br />Datos Personales
          <br />
        <br />
        <div class="container">

            <!-- Primer Nombre -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label1" runat="server" Text="*Nombre" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form" ID="tx_FirstName" runat="server" />
                </div>
                <div class="column six">
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tx_FirstName" CssClass="dnnFormError"></asp:RequiredFieldValidator>
              
                </div>
            </div>

          

            <!-- Primer apellido -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label3" runat="server" Text="*Apellido" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form"  ID="tx_FirstSurname" runat="server" />
                </div>
                <div class="column six">
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tx_FirstSurname" CssClass="dnnFormError"></asp:RequiredFieldValidator>
              
                </div>
            </div>

          


            <!-- genero -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label5" runat="server" Text="*Genero" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:DropDownList CssClass="form2" ID="dd_Gender" runat="server" ReadOnly="True">
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="column six">
                </div>
            </div>



                <!-- Cedula de identificacion -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label666" runat="server" Text="*Documento de Identidad" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form"  ID="tx_CI" runat="server" />
          
                </div>
                <div class="column six">
                         <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tx_CI" CssClass="dnnFormError"></asp:RequiredFieldValidator>
              
                </div>
            </div>


            <!-- birth date -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label7" runat="server" Text="*Fecha de Nacimiento" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">



                    <uc1:DatePicker runat="server" id="dd_BirthDate" />


                </div>
                <div class="column six">
                </div>
            </div>

      

            <!-- cell -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label9" runat="server" Text="Celular" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form"  ID="tx_CellPhone" runat="server" />
                    <asp:TextBox CssClass="form" ID="tx_CellPhoneOLD" runat="server" Visible="False"></asp:TextBox>
                </div>
                <div class="column six">
                </div>
            </div>


            <!-- email -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label10" runat="server" Text="*Email" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form" ID="tx_Email" runat="server" />
               </div>
                <div class="column six">
                       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tx_Email" CssClass="dnnFormError"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email no valido" ControlToValidate="tx_Email" CssClass="dnnFormError" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>

                     <!-- email verify -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label676" runat="server" Text="*Confirma Email" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form" ID="tx_EmailConfirm" runat="server" />
                </div>
                <div class="column six">
                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tx_EmailConfirm" CssClass="dnnFormError"></asp:RequiredFieldValidator>
            
         <asp:CompareValidator Display="Dynamic" ID="EmailCompareValidator" runat="server" ControlToCompare="tx_Email" ControlToValidate="tx_EmailConfirm" ErrorMessage="Los email no coinciden" CssClass="dnnFormError"></asp:CompareValidator>
                 </div>
            </div>

            <br />
             <br />
            Configuración de clave de acceso
             <br />
            <br />


              <!-- Clave -->
                  <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label265" runat="server" Text="*Clave" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form" ID="tx_Password" runat="server" TextMode="Password" />
                </div>
                <div class="column six">
                
             <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obligatorio<br />" ControlToValidate="tx_Password" CssClass="dnnFormError" ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Mínimo 6 caracteres, debe contener letras y numeros<br />" ControlToValidate="tx_Password" CssClass="dnnFormError" ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-zA-Z]).*$"></asp:RegularExpressionValidator> 
                        
             <asp:Label CssClass="texto" ID="Label312" runat="server" Text="Mínimo 6 caracteres, debe contener letras y numeros" HelpText="It's the name of the thing" />
                </div>
            </div>
                 

              <!-- Clave -->
                  <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label352" runat="server" Text="*Confirmar Clave" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:TextBox CssClass="form" ID="tx_PasswordConfirm" runat="server" TextMode="Password" ControlToValidate="tx_PasswordConfirm" />
                </div>
                <div class="column six">
                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="tx_PasswordConfirm" CssClass="dnnFormError" ></asp:RequiredFieldValidator>
            
                    <asp:CompareValidator Display="Dynamic" ID="password_validator" runat="server" ErrorMessage="Las contraseñas no coinciden" CssClass="dnnFormError" ControlToCompare="tx_Password" ControlToValidate="tx_PasswordConfirm"></asp:CompareValidator>
                </div>
            </div>


            
            <br />
             <br />
            Verificación captcha
             <br />
            <br />


                  <!-- capcha -->
                  <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label2" runat="server" Text="*Captcha" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                 
                <cc2:CaptchaControl ID="ctlCaptcha" Text="Ingrese los caracteres de la Imagen." CaptchaHeight="40" CaptchaWidth="150"   ErrorStyle-CssClass="NormalRed" cssclass="Normal" runat="server"  ErrorMessage="Los caracteres ingresados no coinciden"/>


                    </div>
                <div class="column six">

      <asp:Label CssClass="texto" ID="Label4" runat="server" Text="El captcha es sensible a mayúsculas y minúsculas" HelpText="It's the name of the thing" />
               
            </div>
            </div>




        </div>
    </div>

                <!-- separo y le pongo el pie -->
                   <br  /><br  /><br  />
      <asp:Label CssClass="texto" runat="server" ID="Label32" Text="Los campos señalados con asteristo (*) son obligatorios"  />
    <br  />
      <br  />

            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="MasInfo">
                    <!-- TAB-->
    <!-- hMas info -->


    <div id="MasInfo"  >
         <br /> Queremos saber más de ti
          <br />
        <br />
        <div class="container">

            <!-- estado -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label13" runat="server" Text="*Estado" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:DropDownList CssClass="form2" ID="dd_State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dd_State_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:TextBox CssClass="form" ID="tx_StateOLD" runat="server" Visible="False"></asp:TextBox>
                </div>
                <div class="column six">
                </div>
            </div>

            <!-- ciudad -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label14" runat="server" Text="*Cuidad" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                    <asp:DropDownList CssClass="form2" ID="dd_City" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox CssClass="form" ID="tx_CityOLD" runat="server" Visible="False"></asp:TextBox>
                            </ContentTemplate>
                         <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="dd_State" EventName="SelectedIndexChanged" />
                    </Triggers>
                        </asp:UpdatePanel>

                </div>
                <div class="column six">
                </div>
            </div>

          

            <!-- Nacionalidad -->
            <div class="row">
                <div class="column three">
                    <asp:Label CssClass="texto" ID="Label23" runat="server" Text="Nacionalidad" HelpText="It's the name of the thing" />
                </div>
                <div class="column three">
                    <asp:DropDownList CssClass="form2" ID="dd_Country" runat="server">
                        <asp:ListItem Value="-1">&lt;Seleccione Nacionalidad&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="column six">
                </div>
            </div>

     <br /><br />

             <!-- hijos -->
            <div class="row">
                <div class="column twelve">
                    Hijos
                    <br />
       
                </div>
            </div>
               
            
               
            <!-- hijos -->
          <div class="row">
                <div class="column twelve">

                     <uc1:DynamicAddControl runat="server" id="Kid_DynamicAddControl" />

                </div>
            </div>

  

        </div>
    </div>

  <!-- separo y le pongo el pie -->
                   <br  /><br  /><br  />
      <asp:Label CssClass="texto" runat="server" ID="Label6" Text="Los campos señalados con asteristo (*) son obligatorios"  />
    <br  />
      <br  />

            </asp:WizardStep>      
            <asp:WizardStep ID="WizardStep3" runat="server" Title="PreferenciasEmail">
    <!-- TAB-->
    <!-- Preferencias email-->

    <div id="PreferenciasEmail"  >
        <br />
        Preferencias de envio de correo
        <br />  <br />
        <div class="container">

            <!-- Row Label queres info?-->
            <div class="row">
                <div class="column twelve">
                    <asp:Label CssClass="texto" ID="Label29" runat="server" Text="*¿Que informacion de nuestros productos y servicios desea recibir?" HelpText="It's the name of the thing" />
                </div>
            </div>
            <!-- Row Radiobutton si o no 
            <div class="row">
                <div class="column twelve">
                    <asp:RadioButtonList ID="rb_info" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="True">Si</asp:ListItem>
                        <asp:ListItem Value="False">No</asp:ListItem>
                    </asp:RadioButtonList>
                  </div>
             </div>
       -->
                    <!-- topic checkbox list -->
                    <div class="row">
                        <div class="column twelve">
                            <asp:CheckBoxList CssClass="texto"  ID="chbx_Topics" runat="server"></asp:CheckBoxList>

                        </div>
                    </div>
                  
             
               <br />   

             <!-- Row Label Frecuencia?-->
            <div class="row">
                <div class="column twelve">
                    <asp:Label CssClass="texto" ID="Label30" runat="server" Text="*Frecuencia" HelpText="It's the name of the thing" />
                </div>
            </div>

               <!-- Row Radiobutton para la frecuencia -->
            <div class="row">
                <div class="column twelve">
                    <asp:RadioButtonList CssClass="texto"  ID="rb_Frequency" runat="server" RepeatDirection="Horizontal">
                       
                    </asp:RadioButtonList>
                  </div>
             </div>
            

                     
               <br />  
            
             <!-- Row Label Canal?-->
            <div class="row">
                <div class="column twelve">
                    <asp:Label CssClass="texto" ID="Label31" runat="server" Text="*Canal" HelpText="It's the name of the thing" />
                </div>
            </div>

               <!-- canal -->
            <div class="row">
                <div class="column twelve">
                    <asp:CheckBoxList CssClass="texto"  ID="rb_Channel" runat="server" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                  </div>
             </div>
            


               </div>
            </div>
       
  <!-- separo y le pongo el pie -->
                   <br  /><br  /><br  />
      <asp:Label CssClass="texto" runat="server" ID="Label8" Text="Los campos señalados con asteristo (*) son obligatorios"  />
    <br  />
      <br  />
            </asp:WizardStep>

             </WizardSteps>
        <StartNavigationTemplate>
    <asp:LinkButton ID="StartNextButton" runat="server"  Text="Registrar" OnClick="RegisterFirst_Click" />
   </StartNavigationTemplate>
   <StepNavigationTemplate>
    
       <asp:LinkButton ID="StepNextButton" runat="server"  Text="Siguiente" OnClick="NextButton_Click"/>
   </StepNavigationTemplate>
   <FinishNavigationTemplate>
      <asp:LinkButton ID="FinishPreviousButton" runat="server"  CommandName="MovePrevious" Text="Volver" />
       <asp:Label CssClass="texto" runat="server" id="someLabel" Text=" | "/>
      <asp:LinkButton ID="FinishButton" runat="server" CommandName="MoveComplete" Text="Actualizar" />
   </FinishNavigationTemplate>

    </asp:Wizard>



            </div>
      
        </div>


    </div>



    


<!-- invisible stuff -->
<div >
    <asp:Label CssClass="texto" runat="server" ID="tx_CustomerID" Visible="False"/>


</div>
 


                   











      </ContentTemplate>
             
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="CreateWizard" EventName="ActiveStepChanged" />
                    <asp:AsyncPostBackTrigger ControlID="CreateWizard" EventName="CancelButtonClick" />
                    <asp:AsyncPostBackTrigger ControlID="CreateWizard" EventName="FinishButtonClick" />
                    <asp:AsyncPostBackTrigger ControlID="CreateWizard" EventName="NextButtonClick" />
                    <asp:AsyncPostBackTrigger ControlID="CreateWizard" EventName="PreviousButtonClick" />
                    <asp:AsyncPostBackTrigger ControlID="CreateWizard" EventName="PreviousButtonClick" />
                </Triggers>
             
            </asp:UpdatePanel>


                 