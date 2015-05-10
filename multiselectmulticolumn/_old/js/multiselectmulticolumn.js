var data = [
	{ value: 1, label: "Label 1" },
	{ value: 2, label: "Label 2" },
	{ value: 3, label: "Label 3" },
	{ value: 4, label: "Label 4" },
	{ value: 5, label: "Label 5" },
	{ value: 6, label: "Label 6" },
	{ value: 7, label: "Label 7" },
	{ value: 8, label: "Label 8" },
	{ value: 9, label: "Label 9" },
	{ value: 10, label: "Label 10" },
	{ value: 11, label: "Label 11" },
	{ value: 12, label: "Label 12" },
	{ value: 13, label: "Label 13" },
	{ value: 14, label: "Label 14" },
	{ value: 15, label: "Label 15" },
	{ value: 16, label: "Label 16" },
	{ value: 17, label: "Label 17" },
	{ value: 18, label: "Label 18" },
	{ value: 19, label: "Label 19" },
	{ value: 20, label: "Label 20" },
	{ value: 21, label: "Label 21" },
	{ value: 22, label: "Label 22" },
	{ value: 23, label: "Label 23" },
	{ value: 24, label: "Label 24" },
	{ value: 25, label: "Label 25" },
	{ value: 26, label: "Label 26" },
	{ value: 27, label: "Label 27" },
	{ value: 28, label: "Label 28" },
	{ value: 29, label: "Label 29" },
	{ value: 30, label: "Label 30" }
];




(function ($) {	
	var inputTarget;
	var multicol;
	var selectedItems = [];
	
	var droppable;
	var filteredItems;
	var unfilteredItems;
	
	$.fn.multicolselect = function(options) {
		var settings = $.extend({

		}, options );
		
		inputTarget = $(this);
		//inputTarget.hide();
		
		multicol = 
			$("<div class='select multiselectmulticolumn'>"
				+ "<div class='labels'>2 elementos seleccionados</div>"
				+ "<div class='droppable'>"
					+ "<div class='buscador'>"
						+ "<input type='text' id='buscador' class='buscador' />"
						+ "<input type='button' id='selectAll' value='Seleccionar todo'/>"
						+ "<input type='button' id='selectFiltered' value='Seleccionar la búsqueda'/>"
						+ "<input type='button' id='deselectAll' value='Deseleccionar todo'/>"
					+ "</div>"
					+ "<div class='items'>"
						+ "<div id='filteredItems' class='filteredItems'></div>"
						+ "<div id='unfilteredItems' class='unfilteredItems'></div>"
					+ "</div>"
				+ "</div>"
			+ "</div>");
		
		$(multicol).insertAfter(this);
		
		unfilteredItems = $(multicol).find("#unfilteredItems");
		filteredItems = $(multicol).find("#filteredItems");
		
		search();
				
		$(".labels").click(toggleDroppableVisibility);
		
		initEvents();
		
		return this;
	};
	
		
	function initEvents(){
		$(multicol).find("#buscador").keyup(search);
		$(multicol).find("#selectAll").click(selectAll);
		$(multicol).find("#selectFiltered").click(selectFiltered);
		$(multicol).find("#deselectAll").click(deselectAll);
		addCheckboxEvents();
	}
		
	function addCheckboxEvents(){
		$(multicol).find(":checkbox").click(onSelectItem);
	}
	
	function setInputValue(){
		inputTarget.val(selectedItems.join());	
	}
		
	function toggleDroppableVisibility() {
	    if ($(".droppable").css("display") === "none") {
	        $(".droppable").show();
	        //$("body").bind("click", function (e) { toggleDroppableVisibility(); });
	    }
	    else {
	        $(".droppable").hide();
	        //$("body").unbind("click");
	    }
	}

	
	function search(){
		var searchTerm = $("#buscador").val().toLowerCase();
		var applySearch = (searchTerm !== "");
		var ok = "";
		var ko = "";
		
		var searchRegExp = new RegExp(searchTerm, "i");		
		
		for(var i=0; i<data.length; i++){
			var item = data[i];
			var label = item.label;
			var value = item.value;
			var checked = (selectedItems.indexOf("" + value) != -1)? "checked" : "";

			var itemHtml = buildItem(label, value, checked);					
			if (applySearch && label.search(searchRegExp) != -1){
				ok += itemHtml;
			}
			else{
				ko += itemHtml;
			}
		}
		
		$("#filteredItems").html(ok);
		$("#unfilteredItems").html(ko);
		setInputValue();
	}
	
	
	function buildItem(itemLabel, itemValue, itemChecked){
		var itemHtml = 
			"<div class='multiselectitem'>"
				+ "<input type='checkbox' value='" + itemValue + "' " + itemChecked + "/>"
				+ "<span>" + itemLabel + "</span>"
			+ "</div>";
		
		return itemHtml;
	}
	
	
	function onSelectItem(){
		var itemValue = $(this).val();
		
		if ($(this).is(":checked")){
			selectedItems.push(itemValue);
		}
		else{
			var itemPosition = selectedItems.indexOf(itemValue);
			selectedItems.splice(itemPosition, 1);
		}
		setInputValue();
	}
	
	
	function selectAll(){
		$("input:checkbox").prop("checked", true);
		selectedItems = [];
		
		for(var i=0; i<data.length; i++){
			selectedItems.push(data[i].value);
		}
	}

	
	function deselectAll(){
		$("input:checkbox").prop("checked", false);
		selectedItems = [];
	}

	
	function selectFiltered(){
		$("#filteredItems input:checkbox").prop("checked", true);
		
		var checkedItems = $("#filteredItems input:checkbox");
		
		for(var i=0; i<checkedItems.length; i++){
			selectedItems.push(checkedItems[i].value);
		}	
	}
}(jQuery));