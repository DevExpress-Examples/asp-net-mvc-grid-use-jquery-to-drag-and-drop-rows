@Html.DevExpress().GridView(Sub (settings)
                                     settings.Name = "gridOne"
                                     settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridOne"}
                                     settings.Width = 500

                                     settings.KeyFieldName = "CategoryID"
                                     settings.Styles.Table.CssClass = "droppableLeft"
                                     settings.Styles.Row.CssClass = "draggableRow left"
    
End Sub).Bind(Model).GetHtml()