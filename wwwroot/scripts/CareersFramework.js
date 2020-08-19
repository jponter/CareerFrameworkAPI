var seniorityLevel = 1;

      $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
        // alert("ready");




        // we need to populate the professions selector #SelProfessions

      
        loadProfessions();

        //setTimeout(UpdateListClick, 500);


        //populate the skills to learn table
        //setCore();
        //populateSkillsToLearn();


        //update the skills (core and senior atm) totals
        setTimeout(update_core,300);

        //UpdateListClick();

      });

      var update_core = function () {
        //update the core totals
        var core_total = $("#lg1 a").length;
        var core_active = $("#lg1 a.active").length;
        console.log(core_active + " " + core_total);
        $("#core_header").html("Core Skills " + core_active + "/" + core_total);

        //update senior too
        var senior_total = $("#lg2 a").length;
        var senior_active = $("#lg2 a.active").length;
        console.log(senior_active + " " + core_total);
        $("#senior_header").html("Senior Skills " + senior_active + "/" + senior_total);

        //update principle now as well :D 
        var principle_total = $("#lg3 a").length;
        var principle_active = $("#lg3 a.active").length;
        console.log(principle_active + " " + principle_total);
        $("#principle_header").html("Principal Skills " + principle_active + "/" + principle_total);

      }

      var table_contains = function (skill_code) {
        var count;
        console.log("TC: " + skill_code);
        var tableRow = $("#myTable tr td").filter(function () {
          if ($(this).text() == skill_code) {
            count = true;
          }

        });
        if (count == undefined) count = false;
        console.log(count);
        return count;
      }

      var table_count = function (table) {
        
        var count = $("#" + table + " tr").length;
        console.log("TCount: " + table + " : Count = " + count);
        return count;
                
      }

      var setCore = function(){
        console.log("Set Core called");
        seniorityLevel = 1;
        $("#btnSeniority").html("Core");
        clearSkillsToLearn();
        setTimeout(populateSkillsToLearn, 100);
        $("#col2").addClass("disabledbutton");
        $("#col3").addClass("disabledbutton");
      }

      var setSenior = function(){
        console.log("Set Senior called");
        seniorityLevel = 2;
        $("#btnSeniority").html("Senior");
        clearSkillsToLearn();
        //populateSkillsToLearn();
        setTimeout(populateSkillsToLearn, 100);
        $("#col2").removeClass("disabledbutton");
      }

      var setPrinciple = function(){
        console.log("Set Principle called");
        seniorityLevel = 3;
        $("#btnSeniority").html("Principal");
        clearSkillsToLearn();
        //populateSkillsToLearn();
        setTimeout(populateSkillsToLearn, 100);
        $("#col3").removeClass("disabledbutton");
        $("#col2").removeClass("disabledbutton");
      }

      var clearSkillsToLearn = function(){
        console.log("Clear #requiredTable");
        $("#requiredTable tbody tr").remove();
      }

      var clearMySkills = function(){
        console.log("Clear #myTable");
        $("#myTable tbody tr").remove();
      }

var populateSkillsToLearn = function(){
  $("#lg1 > a").each( function() {
          //console.log($(this).attr("id") + $(this).html());
          var req_id= $(this).attr('id');
          var newReqRow = '<tr id=req_' + req_id + '><td>' + req_id + '</td><td>' + $(this).html() + '</td>';
          //$("#requiredTable").find('tbody:first').after(newReqRow);
          $("#requiredTable").append(newReqRow);
        });

        $("#lg1 > a.active").each(function () {
          //remove the skills we already have from skills to learn
          var req_id = $(this).attr('id');
          var req_selector = "#req_" + req_id;
            $(req_selector).remove();
        });

        if(seniorityLevel > 1){
          
        $("#lg2 > a").each( function() {
          //console.log($(this).attr("id") + $(this).html());
          var req_id= $(this).attr('id');
          var newReqRow = '<tr id=req_' + req_id + '><td>' + req_id + '</td><td>' + $(this).html() + '</td>';
          $("#requiredTable").append(newReqRow);
        });

        $("#lg2 > a.active").each(function () {
          //remove the skills we already have from skills to learn
          var req_id = $(this).attr('id');
          var req_selector = "#req_" + req_id;
            $(req_selector).remove();
        });
      }

        if(seniorityLevel > 2){
          
          $("#lg3 > a").each( function() {
            //console.log($(this).attr("id") + $(this).html());
            var req_id= $(this).attr('id');
            var newReqRow = '<tr id=req_' + req_id + '><td>' + req_id + '</td><td>' + $(this).html() + '</td>';
            $("#requiredTable").append(newReqRow);
          });
  
          $("#lg3 > a.active").each(function () {
            //remove the skills we already have from skills to learn
            var req_id = $(this).attr('id');
            var req_selector = "#req_" + req_id;
              $(req_selector).remove();
          });
        }

        
}

function clearSkills(){
  console.log("clearSkills");
  $("#lg1 a.active").removeClass("active");
  $("#lg2 a.active").removeClass("active");
  $("#lg3 a.active").removeClass("active");
}

function clearSkillsAll(){
  console.log("ClearSkillsAll");
  $("#lg1 a").remove();
  $("#lg2 a").remove();
  $("#lg3 a").remove();
}

function resetAll() {
  clearSkillsToLearn();
  clearMySkills();
  setCore();
  update_core();
  clearSkills();

}

function setProf(profid, profname){
  console.log(profid);
  console.log(profname);
  $("#btnProfession").html(profname);

  //from here we need to load the data for all 3 levels for the given professionId
  //https://localhost:44381/api/skills/byAttribute?ProfessionID=2&Level=2
  
  //clear the skills table
  clearSkillsAll();
  
  //set core skills
  var coreSkillsUrl = "https://localhost:44381/api/skills/byAttribute?ProfessionID="+ profid +"&Level=1";
 //set Senior skills
 var seniorSkillsUrl = "https://localhost:44381/api/skills/byAttribute?ProfessionID="+ profid +"&Level=2";
  //set principal skills
  var principalSkillsUrl = "https://localhost:44381/api/skills/byAttribute?ProfessionID="+ profid +"&Level=3";
var alert = false;

  //get the core skills
$.getJSON(coreSkillsUrl, function(data,status){
  console.log("Status: " + status);
    if(status == "success"){
      console.log("getJSON-SkillsCore:");
      console.log(data);

      $(data).each(function (index, obj){

        var text = $.trim(obj.skillText);
        console.log("Ob: " + obj.skillCode);
        console.log("ObTxt: " + text);

        


        //append to the #lg1
        // <a href="#" class="list-group-item list-group-item-action" id=ENG-CORE1>Has strong DevOps
        //                         experience, is
        //                         expert in CICD and code management. This was shown in the engagement: </a>
        $("#lg1").append('<a href="#" class="list-group-item list-group-item-action" id=' + obj.skillCode + '>' + text + '</a>');


      });

    
  }else{
    alert("Database Connection Error");
    alert = true;
  }


});

if(!alert){
//get the Senior Skills
$.getJSON(seniorSkillsUrl, function(data,status){
  console.log("Status: " + status);
    if(status == "success"){
      console.log("getJSON-SkillsSenior:");
      console.log(data);

      $(data).each(function (index, obj){

        var text = $.trim(obj.skillText);
        console.log("Ob: " + obj.skillCode);
        console.log("ObTxt: " + text);

        


        //append to the #lg1
        // <a href="#" class="list-group-item list-group-item-action" id=ENG-CORE1>Has strong DevOps
        //                         experience, is
        //                         expert in CICD and code management. This was shown in the engagement: </a>
        $("#lg2").append('<a href="#" class="list-group-item list-group-item-action" id=' + obj.skillCode + '>' + text + '</a>');


      });

    
  };


});

//get the Principal Skills
$.getJSON(principalSkillsUrl, function(data,status){
  console.log("Status: " + status);
    if(status == "success"){
      console.log("getJSON-SkillsSenior:");
      console.log(data);

      $(data).each(function (index, obj){

        var text = $.trim(obj.skillText);
        console.log("Ob: " + obj.skillCode);
        console.log("ObTxt: " + text);

        


        //append to the #lg1
        // <a href="#" class="list-group-item list-group-item-action" id=ENG-CORE1>Has strong DevOps
        //                         experience, is
        //                         expert in CICD and code management. This was shown in the engagement: </a>
        $("#lg3").append('<a href="#" class="list-group-item list-group-item-action" id=' + obj.skillCode + '>' + text + '</a>');


      });

    
  };


});
} //end alert

setTimeout(UpdateListClick, 100);
clearSkillsToLearn();
clearMySkills();


      setCore();
    

populateSkillsToLearn();

setTimeout(update_core,300);


}

function loadProfessions(){
  var professionsURL = "https://localhost:44381/api/Professions";


  try {    
  $.getJSON(professionsURL, function(data,status) {
    console.log("Status: " + status);
    if(status == "success"){
      console.log("getJSON-Professions:");
      console.log(data);
      var firstRun = true;
      var firstProfessionId  = null;
      var firstProfessionName = null;

      $(data).each(function (index, obj){

        if(firstRun){
          //take the first professionid and name and store it
          console.log("1st run");
          firstProfessionId = obj.professionId;
          firstProfessionName = obj.name;
          firstRun = false;
        }
        
        console.log("Ob: "+ obj.professionId + " " + obj.name);
        //<button class="dropdown-item" type="button">Engineering</button>
        
        $("#selProfession").append('<button class="dropdown-item" type="button"' + 'onclick="setProf(' + obj.professionId + ',\x27' + obj.name + '\x27' + ')">' + obj.name + '</button>')
      });

      setProf(firstProfessionId, firstProfessionName);
      
      
      

    }
  }
)}
catch (e){
  alert(e);
  console.log("error getting professions");
}
}


function UpdateListClick(){
   //set an event on clicking on list items
   $(".list-group-item").click(function () {
    if ($(this).attr("id") != undefined) {
      var code = $(this).attr("id");
      console.log("searching for : " + code);
      console.log("event says the skill code is " + table_contains(code));

    }
    setTimeout(update_core, 100);

    if ($(this).hasClass("active")) {
      console.log("event was fired from active item");
      //remove the skill from the MySkills table
      var selector = "#table_" + code;
      $(selector).remove();

      //add the skill back to the required skills table
      var newReqRow = '<tr id=req_' + code + '><td>' + code + '</td><td>' + $(this).html() + '</td>';
    //$("#requiredTable").find('tbody:last').after(newReqRow);
    $("#requiredTable").append(newReqRow);

    } else {
      console.log("event was fired from inactive item");
      //add skill to MySkills table
      var newTableRow = '<tr id=table_' + code + '><td>' + code + '</td><td>' + $(this).html() + '</td>';
      //$("#myTable").find('tbody:last').after(newTableRow);
      $("#myTable").append(newTableRow);


      //remove the skill from the requiredTbale
      var req_selector = "#req_" + code;
      $(req_selector).remove();
      
    }

  });
}



function MakePDF(){
  //calculate how many items in skillstolearn table
  // todo: find out how long skills to learn is (how many rows and set the pdf length based on that
  // should be around 18 per page and thats about 600 per page length set in html2pdf
var items = table_count("requiredTable");
console.log("MakePDF: " + items);
generatePDF(items*60);

}

function generatePDF(varlength) {
  // Choose the element that our invoice is rendered in.
  const element = document.getElementById("SkillsToLearnPDF");
  // Choose the element and save the PDF for our user.
  console.log("length = " + varlength);
  html2pdf()
    .set({ html2canvas: { scale: 4,   height: varlength , windowWidth: 400 },
           filename: 'SkillsToLearn.pdf'           
            })
    .from(element)
    .save();
}
