<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/dragDropMvc/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/dragDropMvc/Controllers/HomeController.vb))
* [GridModel.cs](./CS/dragDropMvc/Models/GridModel.cs) (VB: [GridModel.vb](./VB/dragDropMvc/Models/GridModel.vb))
* [script.js](./CS/dragDropMvc/Scripts/script.js) (VB: [script.js](./VB/dragDropMvc/Scripts/script.js))
* [_CallbackPanelPartial.cshtml](./CS/dragDropMvc/Views/Home/_CallbackPanelPartial.cshtml)
* [_GridOne.cshtml](./CS/dragDropMvc/Views/Home/_GridOne.cshtml)
* [_Grids.cshtml](./CS/dragDropMvc/Views/Home/_Grids.cshtml)
* [_GridTwo.cshtml](./CS/dragDropMvc/Views/Home/_GridTwo.cshtml)
* **[Index.cshtml](./CS/dragDropMvc/Views/Home/Index.cshtml)**
<!-- default file list end -->
# GridView - How to drag and drop items from one grid to another
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t116869)**
<!-- run online end -->


<p>The example demonstrates how to use the jQuery framework to drag an item from one grid to another.</p>
<p>- Use jQuery UI <a href="http://jqueryui.com/draggable/">Draggable</a> and <a href="http://jqueryui.com/droppable/">Droppable</a> plug-ins;<br />- Define "draggable" and "droppable" items:</p>


```cs
settings.Styles.Table.CssClass = "droppableRight";
settings.Styles.Row.CssClass = "draggableRow right";
```


<p>- Initialize the defined draggable/droppable items via the corresponding jQuery selectors. The "start" event handler can be used to obtain the key of the dragged row and apply conditional styling to it:</p>


```js
start: function (ev, ui) {
    var $sourceElement = $(ui.helper.context);
    var $draggingElement = $(ui.helper);

    var sourceGrid = ASPxClientGridView.Cast($draggingElement.hasClass("left") ? "gridOne" : "gridTwo");

    //style elements
    $sourceElement.addClass("draggingStyle");
    $draggingElement.addClass("draggingStyle");
    $draggingElement.width(sourceGrid.GetWidth());


    //find key
    rowKey = sourceGrid.GetRowKey($sourceElement.index() - 1);
},

```


<p>- Handle the "drop" event of the "droppable" items and perform a callback to the callback panel that has both grids nested inside to perform the data editing functionality.</p>
<p>Select the "script.js" source file and review the comments to find an illustration of the above steps.</p>
<br /><strong>See </strong><strong>A</strong><strong>lso:<br /> </strong><a href="https://www.devexpress.com/Support/Center/p/E1810">How to use jQuery to drag and drop items from one ASPxGridView to another</a>

<br/>


