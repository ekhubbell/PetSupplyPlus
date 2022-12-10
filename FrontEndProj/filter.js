
//get unique values for the desaired column
//{2: ["Cat", "Dog", "Fish", "Hamster", "Chicken", "Rabbit", "Kitten", "Puppy", "Turtle", "Ferret", "Guinea Pig", "Bird", "Rat", "Chinchillas", "Cows", "Ducks", "Gerbils", "Horses", "Pigs", "Sheep"]}
function getUniqueValuesFromColumn() {
    var unique_col_values_dict = {}

    allFilters = document.querySelectorAll(".table-filter")
    allFilters.forEach ((filter_i) => {
        col_index = filter_i.parentElement.getAttribute("col-index");
        //alert(col_index)
        const rows = document.querySelectorAll("#myTable >tbody >tr" )
         //10:57 may have to add tbody  to the table or change it to #myTable > tr as there is currently no tbody
        rows.forEach((row) => {
            cell_value = row.querySelector("td:nth-child("+col_index + ")").innerHTML;
            // if the col index is already present in the dictonairy
            if (col_index in unique_col_values_dict){
                // if the cell value is already present int the array
                if (unique_col_values_dict[col_index].includes(cell_value)){
                    // alert (cell_value + "is already present in array: " + unique_col_values_dict[col_index])
                } else {
                    unique_col_values_dict[col_index].push(cell_value)
                    //alert("Array after adding the cell value :" + unique_col_values_dict[col_index])
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
    updateSelectOptions(unique_col_values_dict)
};

// i have checked the above but cant find any issues.... code wise.. 

// add  <option> tags to the desired columns
function updateSelectOptions(unique_col_values_dict){
    allFilters = document.querySelectorAll(".table-filter")

    allFilters.forEach((filter_i)=> {
        col_index = filter_i.parentElement.getAttribute('col-index')

        unique_col_values_dict[col_index].forEach((i)=> {
            filter_i.innerHTML = filter_i.innerHTML + `\n<option value = "${i}">${i}</option>` 
        });
    });
};

//above is fine code wise..
//create filter_rows() function 

//filter_value_dict {2: value selected}
function filter_rows() {
    allFilters = document.querySelectorAll(".table-filter")
    var filter_value_dict = {}

    allFilters.forEach((filter_i) => {
        col_index = filter_i.parentElement.getAttribute('col-index')
        value = filter_i.value
        if (value != "all"){
            filter_value_dict[col_index] = value;
        }
    });

    var col_cell_value_dict = {};

    const rows = document.querySelectorAll('#myTable tbody tr');// could be #myTable tbody tr
    rows.forEach((row) => {
        var display_row = true; 
        allFilters.forEach ((filter_i) => {
            col_index = filter_i.parentElement.getAttribute('col-index')
            col_cell_value_dict[col_index] = row.querySelector("td:nth-child(" + col_index + ")").innerHTML
        }) //everything above is fine code wise...

        for (var col_i in filter_value_dict) {
            filter_value = filter_value_dict[col_i]
            row_cell_value = col_cell_value_dict[col_i]
    
            if (row_cell_value.indexOf(filter_value) == -1 && filter_value != "all") {
                display_row = false; 
                break;
                
            }
        }
        
        if (display_row == true){
            row.style.display = "table-row"

        } else {
            row.style.display = "none" //23:00
        }

    })

    
}