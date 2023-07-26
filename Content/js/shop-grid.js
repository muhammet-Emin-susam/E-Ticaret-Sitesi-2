

function categories(categoriesName) {
    var i;
    var x = document.getElementsByClassName("Products");
    for (i = 0; i < x.length; i++) {
      x[i].style.display = "none";  
    }
    document.getElementById(categoriesName).style.display = "block";  
  }

  /* Tablinks Navbar JS Start */

  var btn1 = document.getElementById("btn-1");
  var btn2 = document.getElementById("btn-2");
  var btn3 = document.getElementById("btn-3");
  var btn4 = document.getElementById("btn-4");
  var btn5 = document.getElementById("btn-5");
  var btn6 = document.getElementById("btn-6");

  btn1.addEventListener('click',function(){
    btn1.style.color="Red";
    btn2.style.color="black";
    btn3.style.color="black";
    btn4.style.color="black";
    btn5.style.color="black";
    btn6.style.color="black";
    btn1.style.borderBottom="1px solid green";
    btn2.style.borderBottom="none";
    btn3.style.borderBottom="none";
    btn4.style.borderBottom="none";
    btn5.style.borderBottom="none";
    btn6.style.borderBottom="none";
    
  });
  btn2.addEventListener('click',function(){
    btn1.style.color="black";
    btn2.style.color="Red";
    btn3.style.color="black";
    btn4.style.color="black";
    btn5.style.color="black";
    btn6.style.color="black";
    btn2.style.borderBottom="1px solid green";
    btn1.style.borderBottom="none";
    btn3.style.borderBottom="none";
    btn4.style.borderBottom="none";
    btn5.style.borderBottom="none";
    btn6.style.borderBottom="none";
   
  });
  btn3.addEventListener('click',function(){
    btn1.style.color="black";
    btn2.style.color="black";
    btn3.style.color="Red";
    btn4.style.color="black";
    btn5.style.color="black";
    btn6.style.color="black";
    btn3.style.borderBottom="1px solid green";
    btn1.style.borderBottom="none";
    btn2.style.borderBottom="none";
    btn4.style.borderBottom="none";
    btn5.style.borderBottom="none";
    btn6.style.borderBottom="none";

  });
  btn4.addEventListener('click',function(){
    btn1.style.color="black";
    btn2.style.color="black";
    btn3.style.color="black";
    btn4.style.color="Red";
    btn5.style.color="black";
    btn6.style.color="black";
    btn4.style.borderBottom="1px solid green";
    btn1.style.borderBottom="none";
    btn2.style.borderBottom="none";
    btn3.style.borderBottom="none";
    btn5.style.borderBottom="none";
    btn6.style.borderBottom="none";
   
  });
  btn5.addEventListener('click',function(){
    btn1.style.color="black";
    btn2.style.color="black";
    btn3.style.color="black";
    btn4.style.color="black";
    btn5.style.color="Red";
    btn6.style.color="black";
    btn5.style.borderBottom="1px solid green";
    btn1.style.borderBottom="none";
    btn2.style.borderBottom="none";
    btn3.style.borderBottom="none";
    btn4.style.borderBottom="none";
    btn6.style.borderBottom="none";
  });
  btn6.addEventListener('click',function(){
    btn1.style.color="black";
    btn2.style.color="black";
    btn3.style.color="black";
    btn4.style.color="black";
    btn5.style.color="black";
    btn6.style.color="Red";
    btn6.style.borderBottom="1px solid green";
    btn1.style.borderBottom="none";
    btn2.style.borderBottom="none";
    btn3.style.borderBottom="none";
    btn4.style.borderBottom="none";
    btn5.style.borderBottom="none";
 });

 /* Tablinks Navbar JS End */