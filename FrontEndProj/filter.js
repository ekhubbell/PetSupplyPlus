
//get unique values for the desaired column
//{2: ["Cat", "Dog", "Fish", "Hamster", "Chicken", "Rabbit", "Kitten", "Puppy", "Turtle", "Ferret", "Guinea Pig", "Bird", "Rat", "Chinchillas", "Cows", "Ducks", "Gerbils", "Horses", "Pigs", "Sheep"]}
function getUniqueValuesFromColumn() {
    var unique_col_values_dict = {}

    allFilters = document.querySelector(".table-filter")
    allFilters.forEach ((filter_i) => {
        col_index = filter_i.parentElement.getAttribute("col-index");
        //alert(col_index)
        const rows = document.querySelectorAll("#myTable >tr" )
         //10:57 may have to add tbody  to the table or change it to #myTable > tr as there is currently no tbody
        rows.forEach((row) => {
            cell_value = row.querySelector("td:nth-child("+col_index+")").innerHTML;
            // if the col index is already present in the dictonairy
            if (col_index in unique_col_values_dict){
                // if the cell value is already present int the array
                if (unique_col_values_dict[col_index].includes(cell_value)){
                    alert (cell_value + "is already present in array: " + unique_col_values_dict[col_index])
                } else {
                    unique_col_values_dict[col_index].push(cell_value)
                    alert("Array after adding the cell value :" + unique_col_values_dict[col_index])
                }

            }
            else {
                unique_col_values_dict[col_index] = new Array(cell_value)
            }
            
        });
    });
    for (i in unique_col_values_dict) {
        alert("column index : " + i + "has unique values: \n" + unique_col_values_dict[i]); //14:57
    }
};
// add  <option> tags to the desired columns
function updateSelectOptions(unique_col_values_dict){
    allFilters = document.querySelectorAll(".table-filter")
};
//create filter_rows() function 