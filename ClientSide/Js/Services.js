var sername=document.getElementById('sername');
var serdesc=document.getElementById('serdesc');
var insertser=document.getElementById('btn-insser');
var ddlServiceIdId=document.getElementById('ServiceIdId');
var tabbody=document.getElementById('tabbody');
var updateserdiv=document.getElementById('updatediv');
updateserdiv.style.display='none';
var inserteserdiv=document.getElementById('adddiv');
var btnupdate=document.getElementById('btn-update');
let updateId;
var lbsername=document.getElementById('lbsername');
var lbserdesc=document.getElementById('lbserdesc');
let url='https://localhost:7036/api/services';
validateservicefun=()=>{
    let validate=true;

    if(sername.value==''){
       lbsername.innerHTML='Services Name: * [Required]';
       lbsername.style.color='red';
           validate=false;
        }else if(!isNaN(sername.value)){
            lbsername.innerHTML='[Not a Number]';
            lbsername.style.color='red';
             validate=false;

       
        }else{
         lbsername.innerHTML='Services Name: *';
         lbsername.style.color='white';
          validate=true;
        }
     
        
        if(serdesc.value==''){
            lbserdesc.innerHTML='Services Description: * [Required]';
            lbserdesc.style.color='red';
              validate=false;           
        }else if(!isNaN(serdesc.value)){
            lbserdesc.innerHTML='[Not a Number]';
            lbserdesc.style.color='red';
             validate=false;
        }
        else{
            lbserdesc.innerHTML='Services Description: *';
            lbserdesc.style.color='white';
              validate=true; 
        }
        return validate;
    }
inserservices=()=>{
 
    let objservices={
        name:sername.value,
        description:serdesc.value
    }
    let data=JSON.stringify(objservices);
    if(validateservicefun()==false)
    return;
    $.ajax({
      url:`${url}/PostSaveData`,
      method:'POST',
      contentType:'application/json',
      data:data,
      cache:false,
      success:function(){
       
        console.log(serdesc.value);
        alert("ok saved");
        servitable.ajax.reload();
        showservices();
        sername.value='';
        serdesc.value='';
      } 
       
    });
}
// showservicestab=()=>{
//     let table='';
//     $.ajax({
       
//         url:`${url}/GetAll`,
//         method:'GET',
//         caches:false,
//         success:function(data){
//           for(let i in data){
//           table+=`
//           <tr>
                     
//           <td>${data[i].id}</td>
//           <td>${data[i].name}</td>
//           <td>${data[i].description}</td>

          
//           <td>
//               <button class="btn btn-success" onclick=getservicewillupdate(${data[i].id})>
//                   <i class="fa-solid fa-pen-to-square"></i>
//               </button>
//               <button class="btn btn-danger" onclick=Deleteservice(${data[i].id})>
//                <i class="fa-solid fa-trash"></i>
//                </button>
//           </td>
//           </tr>`;
 
 
//         }
//         tabbody.innerHTML=table;
//         }
//     });
// }
//drop down
showservices=()=>{
    let item='';
    item+=`<option value=0>---Select Services---</option>`;
    $.ajax({
        url:`${url}/GetAll`,
        method:'GET',
        caches:false,
        success:function(data){
          for(let i in data){
            item+=`<option value=${data[i].id}>${data[i].name}</option>`
          }
          ddlServiceIdId.innerHTML=item;
          } 
       
        
    });
}
Deleteservice=(id)=>{
    if(confirm('Are you sure deleted this service..?')==true)
    {
        $.ajax({
            url:`${url}/${id}`,
            method:'Delete',
            caches:false,
            success:function(data){
                servitable.ajax.reload();    
            }
        });
    }
}
//in table
 getservicewillupdate=(id)=>{
    updateserdiv.style.display='block';
    inserteserdiv.style.display='none';
    $.ajax({
        url:`${url}/GetByID/${id}`,
        method:'GET',
        caches:false,
        success:function(data){
            console.log(data.name);

            sername.value=data.name;
            serdesc.value=data.description;
            updateId=data.id;
        },
    });
}
Editeservices=()=>{
    validateservicefun();
        let objservices={
        name:sername.value,
        description:serdesc.value
    }
    let data=JSON.stringify(objservices);
    $.ajax({
      url:`${url}/PutEdite/${updateId}`,
      method:'PUT',
      contentType:'application/json',
      data:data,
      cache:false,
      success:function(){
         alert("ok saved");
         servitable.ajax.reload();
         showservices();
        sername.value='';
        serdesc.value='';
        updateserdiv.style.display='none';
        inserteserdiv.style.display='block';
      } 
       
    });
}

insertser.addEventListener('click',inserservices);
btnupdate.addEventListener('click',Editeservices)
showservices();
 






