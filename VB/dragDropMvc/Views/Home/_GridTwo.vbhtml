@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "gridTwo"
                                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridTwo"}
                                settings.Width = 500

                                settings.KeyFieldName = "CategoryID"
                                settings.Styles.Table.CssClass = "droppableRight"
                                settings.Styles.Row.CssClass = "draggableRow right"
    
                            End Sub).Bind(Model).GetHtml()