var codetxt=document.getElementById('codetxt');
var serial=document.getElementById('serailtxt');
var operation=document.getElementById('optxt');
var price=document.getElementById('pricetxt');
var catid=document.getElementById('ddlCatIdId');
var addcard=document.getElementById('addcard');
var tbody=document.getElementById('tabcard');
let url3='https://localhost:7036/api/Cards'

window.mynamespace = window.mynamespace || {};
var lbcode=document.getElementById('lbcode');
var lbserial=document.getElementById('lbserial');
var lbop=document.getElementById('lbop');
var lbprice=document.getElementById('lbprice');
var lbcategoryid=document.getElementById('lbcategoryid');
var lbduplicate=document.getElementById('lbduplicate');
lbduplicate.style.display='none';
validateCardfun=()=>{
    let validate=true;

    if(codetxt.value==''){
        lbcode.innerHTML='Code Card : * [Required]';
        lbcode.style.color='red';
           validate=false;
        }else if(isNaN(codetxt.value)){
            lbcode.innerHTML='[Not a char]';
            lbcode.style.color='red';
             validate=false;

       
        }else{
            lbcode.innerHTML='Code Card : *';
            lbcode.style.color='white';
          validate=true;
        }
     
        
        if(serial.value==''){
            lbserial.innerHTML='Card Serial : * [Required]';
            lbserial.style.color='red';
              validate=false;           
        }else if(isNaN(serial.value)){
            lbserial.innerHTML='[Not a Number]';
            lbserial.style.color='red';
             validate=false;
        }
        else{
            lbserial.innerHTML='Card Serial : *';
            lbserial.style.color='white';
              validate=true; 
        }


        if(operation.value==''){
            lbop.innerHTML='Operational Number : * [Required]';
            lbop.style.color='red';
              validate=false;           
        }else if(isNaN(serial.value)){
            lbop.innerHTML='[Not a Number]';
            lbop.style.color='red';
             validate=false;
        }
        else{
            lbop.innerHTML='Operational Number : *';
            lbop.style.color='white';
              validate=true; 
        }


        if(price.value==''){
            lbprice.innerHTML='Card Price: * [Required]';
            lbprice.style.color='red';
              validate=false;           
        }else if(isNaN(price.value)){
            lbprice.innerHTML='[Not a Char]';
            lbprice.style.color='red';
             validate=false;
        }
        else{
            lbprice.innerHTML='Card Price: *';
            lbprice.style.color='white';
              validate=true; 
        }

        if(catid.value==''||catid.value==0){
            lbcategoryid.innerHTML='Card Category: * [Required]';
            lbcategoryid.style.color='red';
              validate=false;           
        }
        else{
            lbcategoryid.innerHTML='Card Category: *';
            lbcategoryid.style.color='white';
              validate=true; 
        }



        return validate;
    }

insertcard=()=>{
   
    let objservices={
        code:codetxt.value,
        serial:serial.value,
        operationnumber:operation.value,
        price:price.value,
        catid:catid.value
    }
    let data=JSON.stringify(objservices);
    if(validateCardfun()==false)
    return;
     $.ajax({
      url:`${url3}/PostSaveData`,
      method:'POST',
      contentType:'application/json',
      data:data,
      cache:false,
      success:function(){
        alert("ok saved");
        cardtable.ajax.reload();
        codetxt.value='';
        serial.value='';
        operation.value='';
        price.value='';
        catid.value='';
        lbduplicate.style.display='none';
      } ,error(){
        lbduplicate.style.display='block';
      }
       
    });
}
 
printcard=(id)=>{
    $.ajax({
        url:`${url3}/GetByID/${id}`,
        method:'GET',
        caches:false,
        success:function(data){
            console.log(data.code);
            DeleteCard(id);
            
            categorytab.ajax.reload();
          }
    });

}
DeleteCard=(id)=>{
     
        $.ajax({
            url:`${url3}/${id}`,
            method:'Delete',
            caches:false,
            success:function(data){
              cardtable.ajax.reload();
            }
        });
    
  }

addcard.addEventListener('click',insertcard);
