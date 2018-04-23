@Html.DevExpress().CallbackPanel(Sub(settings)
                                     settings.Name = "CallbackPanel"
                                     settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "CallbackPanelPartial"}

                                     settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
    
                                     settings.SetContent(Sub()
                                                             Html.RenderPartial("_Grids")
                                                         End Sub)

                                     settings.ClientSideEvents.EndCallback = "OnPanelEndCallback"
                                 End Sub
).GetHtml()