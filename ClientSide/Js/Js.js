let cardtable;
$(document).ready( function () {
    cardtable= $('#tableCard').DataTable({
        "ajax":{
            "url":`${url3}/GetAll`,
            "dataSrc":"",
        },
        "columns":[
            {"data":"id"},
            {"data":"code"},
            {"data":"serial"},
            {"data":"operationnumber"},
            {"data":"price"},
            {"data":"catid"},
            {
                "data":"id",
                "render":(id)=>{
                    return `<button class="btn btn-success" onclick="printcard(${id})">
                    <i class="fa-solid fa-print"></i>
                     </button>`
                }
            }


        ]
    });
} );

let categorytab;
$(document).ready(
     function () {
    categorytab=$('#tablecategory').DataTable({
        "ajax":{
            "url":`${url2}/GetAll`,
            "dataSrc":"",
        },
        "columns":[
            {"data":"id"},
            {"data":"name"},
            {"data":"service_id"},
            {"data":"amount"},
           
            {
                "data":"id",
                "render":(id)=>{
                    return `<button class="btn btn-success" onclick=getcategorywillupdate(${id})>
                    <i class="fa-solid fa-pen-to-square"></i>
                </button>
                <button class="btn btn-danger" onclick=DeleteCategory(${id})>
                 <i class="fa-solid fa-trash"></i>
                 </button>`
                }
            }


        ]
    });
 } 
);

let servitable;
$(document).ready( function () {
servitable=$('#tableServices').DataTable({
        "ajax":{
            "url":`${url}/GetAll`,
            "dataSrc":"",
        },"columns":[
            {"data":"id"},
            {"data":"name"},
            {"data":"description"},
            {
                "data":"id",
                 "render":(id)=>{
                    return  ` <button class="btn btn-success" onclick=getservicewillupdate(${id})>
                    <i class="fa-solid fa-pen-to-square"></i>
                </button>
                <button class="btn btn-danger" onclick=Deleteservice(${id})>
                 <i class="fa-solid fa-trash"></i>
                 </button>`
                 }

        
        
        }
        ]

    });
});