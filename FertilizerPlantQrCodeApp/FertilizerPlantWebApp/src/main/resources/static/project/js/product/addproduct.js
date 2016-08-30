$(function() {
	$("select option[value='placeholder_option']").attr("selected","selected");
	
	//click the add new
	$('#add_product_select').change(function() {
		var selected = $("#add_product_select").val();
		if (selected === "select_add") {
			$('#addProductModal').modal('show'); 
		} 
	});
	
	//added new product name back into the selection box
	$('.add_product_name_model_close_btn').click(function(){
		var input_product_name = $('#add_product_name_modal_input').val();
		console.log("new product name is "+input_product_name);
		var new_product_option = new Option(input_product_name, input_product_name);
		$('#add_product_select').prepend($(new_product_option));
		$('#add_product_select option:first').attr("selected","selected");
	});
});