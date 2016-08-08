$(function() {
	
	$("select option[value='placeholder_option']").attr("selected","selected");
	
	//click the add new
	$('#add_product_brand_select').change(function() {
		var selected = $("#add_product_brand_select").val();
		if (selected === "select_add") {
			$('#addBrandModal').modal('show'); 
		} 
	});
	
	//added new brand back into the selection box
	$('.add_product_brand_model_close_btn').click(function(){
		var input_brand_name = $('#add_product_brand_modal_input').val();
		console.log("new brand name is "+input_brand_name);
		var new_brand_option = new Option(input_brand_name, input_brand_name);
		$('#add_product_brand_select').prepend($(new_brand_option));
		$('#add_product_brand_select option:first').attr("selected","selected");
	});
});