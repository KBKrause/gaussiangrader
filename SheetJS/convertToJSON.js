// First, we import our excel spreadsheet.

$("#inputExcel").change(function(e) {
  var reader = new FileReader();

  reader.readAsArrayBuffer(e.target.files[0]);

  reader.onload = function(e) {
    var data = new Uint8Array(reader.result);
    var wb = XLSX.read(data, { type: "array" });
    var sheetName = XLSX.first_sheet_name;

    var htmlstr = XLSX.write(wb, {
      sheet: sheetName,
      type: "binary",
      bookType: "html"
    });
    $("#wrapper")[0].innerHTML += htmlstr;
  };
});


// now that we have our spreadsheet displaying on an HTML page, we convert the data to a JSON object.

var fullPath = document.getElementById("inputExcel").value;
if (fullPath) {
  var startIndex =
    fullPath.indexOf("\\") >= 0
      ? fullPath.lastIndexOf("\\")
      : fullPath.lastIndexOf("/");
  var filename = fullPath.substring(startIndex);
  console.log(filename);
  if (filename.indexOf("\\") === 0 || filename.indexOf("/") === 0) {
    filename = filename.substring(1);
  }
  alert(filename);
}

var url = "sheet num1.xlsx";
//console.log(filename);

/* set up async GET request */
var req = new XMLHttpRequest();
req.open("GET", url, true);
req.responseType = "arraybuffer";

req.onload = function(e) {
  var data = new Uint8Array(req.response);
  var workbook = XLSX.read(data, { type: "array" });

  /* DO SOMETHING WITH workbook HERE */

  var first_sheet_name = workbook.SheetNames[0];
  /* Get worksheet */
  var worksheet = workbook.Sheets[first_sheet_name];

  var jsonObject = XLSX.utils.sheet_to_json(worksheet);

  console.log(jsonObject);
}

req.send();

