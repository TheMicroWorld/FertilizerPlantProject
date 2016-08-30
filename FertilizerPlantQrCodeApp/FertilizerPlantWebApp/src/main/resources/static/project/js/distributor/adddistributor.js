$(function() {
	$("select option[value='placeholder_option']").attr("selected","selected");
	
	//click the add new
	$('#add_distributor_select').change(function() {
		var selected = $("#add_distributor_select").val();
		if (selected === "select_add") {
			$('#adddistributorModal').modal('show'); 
		} 
	});
	
	//added new distributor name back into the selection box
	$('.add_distributor_name_model_close_btn').click(function(){
		var input_distributor_name = $('#add_distributor_name_modal_input').val();
		console.log("new distributor name is "+input_distributor_name);
		var new_distributor_option = new Option(input_distributor_name, input_distributor_name);
		$('#add_distributor_select').prepend($(new_distributor_option));
		$('#add_distributor_select option:first').attr("selected","selected");
	});
});