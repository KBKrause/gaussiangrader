$("#inputExcel").change(function(e) {
  var reader = new FileReader();

  reader.readAsArrayBuffer(e.target.files[0]);

  reader.onload = function(e) {
    var data = new Uint8Array(reader.result);
    var wb = XLSX.read(data, { type: "array" });

    var htmlstr = XLSX.write(wb, {
      sheet: "sheet num1",
      type: "binary",
      bookType: "html"
    });
    $("#wrapper")[0].innerHTML += htmlstr;
      
  };
});