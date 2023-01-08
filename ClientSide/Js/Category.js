 var ServiceIdId=document.getElementById('ServiceIdId');
var catnumber=document.getElementById('catnumber');
var bbody=document.getElementById('catbody');
var insertbtn=document.getElementById('addcate');
var catname=document.getElementById('catname');
var ddlCatIdId=document.getElementById('ddlCatIdId');
var updatecatbtn=document.getElementById('updatecat');
var divupdate=document.getElementById('divupdate');
divupdate.style.display='none';
var insertdiv=document.getElementById('insertdiv');
let url2='https://localhost:7036/api/Category';
 let Idupdate;
 window.mynamespace = window.mynamespace || {};
var lbcatname=document.getElementById('lbcatname');
var lbcatserid=document.getElementById('lbcatserid');
var lbamount=document.getElementById('lbamount');


validatecategoryfun=()=>{
  let validate=true;
 
  if(catname.value==''){
    lbcatname.innerHTML='Category Name : * [Required]';
    lbcatname.style.color='red';
         validate=false;
      }else if(!isNaN(catname.value)){
          lbcatname.innerHTML='[Not a Number]';
          lbcatname.style.color='red';
           validate=false;

     
      }else{
        lbcatname.innerHTML='Category Name : *';
        lbcatname.style.color='white';
        validate=true;
      }
   
      
      if(catnumber.value==""){
        lbamount.innerHTML='Card amuont: * [Required]';
        lbamount.style.color='red';
            validate=false;           
        }else if(isNaN(catnumber.value)){
        lbamount.innerHTML='[Not a Character]';
        lbamount.style.color='red';
            validate=false; 
        }else{
        lbamount.innerHTML='Card amuont: *';
        lbamount.style.color='white';
            validate=true; 
      }

      if(ServiceIdId.value ==''||ServiceIdId.value ==null||ServiceIdId.value ==0){
        lbcatserid.innerHTML='Category Service: * [Required]';
        lbcatserid.style.color='red';
        validate=false;
      }else{
        lbcatserid.innerHTML='Category Service: *';
        lbcatserid.style.color='White';
        validate=true;
      }
      return validate;
  }

insercategory=()=>{
    let objcat={
        name:catname.value,
        amount: catnumber.value,
        service_id:ServiceIdId.value
    }
     let data=JSON.stringify(objcat);
  

     if(validatecategoryfun()==false)
     return;
     $.ajax({
      url:`${url2}/PostSaveData`,
      method:'POST',
      contentType:'application/json',
      data:data,
      cache:false,
      success:function(){
        alert("ok saved");
        categorytab.ajax.reload();
         showCategory();
        catname.value='';
         catnumber.value='';
        ServiceIdId.value='';

      }
    });
}
// mynamespace.showcategorytab=()=>{
//     let table='';
//     $.ajax({
       
//         url:`${url2}/GetAll`,
//         method:'GET',
//         caches:false,
//         success:function(data){
            
//           for(let i in data){
//           table+=`
//           <tr>
                     
//           <td>${data[i].name}</td>          
//           <td>${data[i].service_id}</td>
//           <td>${data[i].amount}</td>  
                
//           <td>
//               <button class="btn btn-success" onclick=getcategorywillupdate(${data[i].id})>
//                   <i class="fa-solid fa-pen-to-square"></i>
//               </button>
//               <button class="btn btn-danger" onclick=DeleteCategory(${data[i].id})>
//                <i class="fa-solid fa-trash"></i>
//                </button>
//           </td>
//           </tr>`;
 
 
//         }

//         bbody.innerHTML=table;
//         }
//     });
// }

showCategory=()=>{
  let item='';
  item+=`<option value=0>---Select Services---</option>`;
  $.ajax({
      url:`${url2}/GetAll`,
      method:'GET',
      caches:false,
      success:function(data){
        for(let i in data){
          item+=`<option value=${data[i].id}>${data[i].name}</option>`
        }
        ddlCatIdId.innerHTML=item;
        } 
     
      
  });
}
DeleteCategory=(id)=>{
  if(confirm('Are you sure deleted this service..?')==true)
  {
      $.ajax({
          url:`${url2}/${id}`,
          method:'Delete',
          caches:false,
          success:function(data){
            
            categorytab.ajax.reload();
            showCategory();
          }
      });
  }
}
getcategorywillupdate=(id)=>{
  insertdiv.style.display='none';
  divupdate.style.display='block';
  $.ajax({
      url:`${url2}/GetByID/${id}`,
      method:'GET',
      caches:false,
      success:function(data){
          catname.value=data.name;
          ServiceIdId.value=data.service_id;
          catnumber.value=data.amount;
          Idupdate=data.id;
      },
  });
}
EditeCategory=()=>{
   let objcat={
    name:catname.value,
    amount: (catnumber.value),
    service_id:(ServiceIdId.value)
}
 let data=JSON.stringify(objcat);
//  if(validatecategoryfun()==false)
//  return;
$.ajax({
  url:`${url2}/PutEdite/${Idupdate}`,
  method:'PUT',
  contentType:'application/json',
  data:data,
  cache:false,
  success:function(){
    alert("ok saved");
    
    categorytab.ajax.reload();
    showCategory();
    catname.value='';
     catnumber.value='';
    ServiceIdId.value='';
    insertdiv.style.display='block';
  divupdate.style.display='none';
  },error:function(){
    alert('Error Ocured');
  }
});
}











updatecatbtn.addEventListener('click',EditeCategory);
insertbtn.addEventListener('click',insercategory);
 showCategory();