// First, we import our excel spreadsheet.
var filename = "";

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
  filename = fullPath.substring(startIndex);
  if (filename.indexOf("\\") === 0 || filename.indexOf("/") === 0) {
    filename = filename.substring(1);
  }
  alert(filename);
}
