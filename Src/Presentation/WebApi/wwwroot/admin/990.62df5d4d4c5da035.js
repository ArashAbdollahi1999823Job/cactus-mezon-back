"use strict";(self.webpackChunkadminFrontCactusMezon=self.webpackChunkadminFrontCactusMezon||[]).push([[990],{4990:(j,_,r)=>{r.r(_),r.d(_,{ChatModule:()=>q});var p=r(6814),u=r(7852),e=r(4769),C=r(7438),x=r(4567),g=r(553),v=function(o){return o[o.notImportant=0]="notImportant",o[o.HaveMessage=1]="HaveMessage",o[o.DontHaveMessage=2]="DontHaveMessage",o}(v||{});class w{constructor(){this.hasMessage=v.notImportant}}var P=r(8592),b=r(9724),O=r(9229);function y(o,i){1&o&&(e.TgZ(0,"span",17),e._UZ(1,"i",18),e.qZA())}function N(o,i){if(1&o&&(e.ynx(0),e.YNc(1,y,2,0,"span",16),e.BQk()),2&o){const t=i.$implicit,n=e.oxw(2).$implicit;e.xp6(1),e.Q6J("ngIf",t.askerPhoneNumber==n.askerPhoneNumber&&t.responderPhoneNumber==n.responderPhoneNumber||t.askerPhoneNumber==n.responderPhoneNumber&&t.responderPhoneNumber==n.askerPhoneNumber)}}function S(o,i){if(1&o&&(e.ynx(0),e.YNc(1,N,2,1,"ng-container",5),e.BQk()),2&o){const t=i.ngIf;e.xp6(1),e.Q6J("ngForOf",t)}}function Z(o,i){if(1&o){const t=e.EpF();e.ynx(0),e.TgZ(1,"div",6)(2,"a",7)(3,"div",8),e._UZ(4,"img",9),e.qZA()(),e._UZ(5,"span",10),e.ALo(6,"async"),e.YNc(7,S,2,1,"ng-container",11),e.ALo(8,"async"),e.TgZ(9,"div",12)(10,"div",13),e._uU(11),e.qZA(),e.TgZ(12,"div",14),e.NdJ("click",function(){const c=e.CHM(t).$implicit,d=e.oxw();return e.KtG(d.groupDelete(c.name))}),e._UZ(13,"i",15),e.qZA()()(),e.BQk()}if(2&o){const t=i.$implicit,n=e.oxw();e.xp6(2),e.Q6J("routerLink",t.askerPhoneNumber),e.xp6(3),e.ekj("display-block",e.lcZ(6,5,n.presenceService.usersOnline$).includes(t.askerPhoneNumber)),e.xp6(2),e.Q6J("ngIf",e.lcZ(8,7,n.presenceService.messageUnReadDtos$)),e.xp6(4),e.Oqu(t.asker)}}let D=(()=>{class o{constructor(t,n,s,c,d,f,m){this.userService=t,this.presenceService=n,this.router=s,this.authService=c,this.chatService=d,this.ef=f,this.toastService=m,this.backendUrlPicture=g.N.setting.url.backendUrlPicture,this.expand=!1}ngOnInit(){this.groupGetAll()}groupGetAll(){let t=new w;t.name=this.authService.getPhoneNumber(),t.hasMessage=v.HaveMessage,this.chatService.groupSearchDtoSet(t),this.chatService.groupGetAll().subscribe(n=>{n&&this.chatService.groupDtos.next(n)})}toggleExpand(){this.expand=!this.expand,this.navEl=this.ef.nativeElement.getElementsByClassName("nav")[0],this.logoEl=this.ef.nativeElement.getElementsByClassName("logo")[0],this.expand?(this.navEl.classList.add("width200"),this.navEl.classList.remove("width75"),this.logoEl.classList.add("animateRight"),this.logoEl.classList.remove("animateLeft")):(this.navEl.classList.add("width75"),this.navEl.classList.remove("width200"),this.logoEl.classList.remove("animateRight"),this.logoEl.classList.add("animateLeft"))}groupDelete(t){confirm(g.N.messages.common.doYouWantToDeleteGroup)&&this.chatService.groupDelete(t).subscribe(n=>{1==n&&this.toastService.success(g.N.messages.common.groupDeleteSuccess),this.groupGetAll()}),this.router.navigateByUrl("Chat")}}return o.\u0275fac=function(t){return new(t||o)(e.Y36(P.K),e.Y36(b.Q),e.Y36(u.F0),e.Y36(x.e),e.Y36(C.a),e.Y36(e.SBq),e.Y36(O._W))},o.\u0275cmp=e.Xpm({type:o,selectors:[["chat-nav"]],decls:7,vars:3,consts:[[1,"nav"],[1,"logo-container"],[1,"logo",3,"click"],[1,"fa","fa-arrow-alt-circle-left"],[1,"logo-text"],[4,"ngFor","ngForOf"],[1,"user-container"],[3,"routerLink"],[1,"user-img"],["src","assets/images/userIcon.png"],[1,"show-online-user"],[4,"ngIf"],[1,"information"],[1,"name"],[1,"delete-group",3,"click"],[1,"fa","fa-trash-restore-alt"],["class","message-count",4,"ngIf"],[1,"message-count"],[1,"fa-solid","fa-envelope"]],template:function(t,n){1&t&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2),e.NdJ("click",function(){return n.toggleExpand()}),e._UZ(3,"i",3),e.qZA(),e._UZ(4,"div",4),e.qZA(),e.YNc(5,Z,14,9,"ng-container",5),e.ALo(6,"async"),e.qZA()),2&t&&(e.xp6(5),e.Q6J("ngForOf",e.lcZ(6,1,n.chatService.groupDtos$)))},dependencies:[p.sg,p.O5,u.rH,p.Ov],styles:[".nav[_ngcontent-%COMP%]{background-color:#fffc;width:75px;height:calc(100vh - 70px);overflow:scroll}.nav[_ngcontent-%COMP%]   .logo-container[_ngcontent-%COMP%]{width:75px;height:75px;display:flex;align-items:center}.nav[_ngcontent-%COMP%]   .logo-container[_ngcontent-%COMP%]   .logo[_ngcontent-%COMP%]{width:60px;height:60px;border-radius:5px;background-color:#000;color:#fff;font-size:30px;text-align:center;line-height:70px;margin-right:7px}.nav[_ngcontent-%COMP%]   .user-container[_ngcontent-%COMP%]{width:200px;height:75px;display:flex;align-items:center;position:relative}.nav[_ngcontent-%COMP%]   .user-container[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]{width:125px;height:75px;text-align:center}.nav[_ngcontent-%COMP%]   .user-container[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]   .name[_ngcontent-%COMP%]{font-size:15px}.nav[_ngcontent-%COMP%]   .user-container[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]   .delete-group[_ngcontent-%COMP%]{width:50px;height:auto;border:1px solid black;border-radius:5px;margin:0 auto}.nav[_ngcontent-%COMP%]   .user-container[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]   .user-img[_ngcontent-%COMP%]{width:60px;height:60px;border-radius:5px;background-color:#8b4513;margin-right:7px;border:1px solid black;overflow:hidden}.nav[_ngcontent-%COMP%]   .user-container[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]   .user-img[_ngcontent-%COMP%]   img[_ngcontent-%COMP%]{z-index:1;width:100%;height:100%}.nav[_ngcontent-%COMP%]   .show-online-user[_ngcontent-%COMP%]{width:10px;height:10px;background-color:green;border-radius:50%;position:absolute;bottom:10px;right:3px;z-index:2;display:none;animation-name:_ngcontent-%COMP%_fade;animation-duration:.3s;animation-direction:alternate-reverse;animation-iteration-count:infinite}.nav[_ngcontent-%COMP%]   .message-count[_ngcontent-%COMP%]{width:30px;height:30px;border-radius:50%;position:absolute;top:-12px;right:0;z-index:2;color:#000;font-size:20px;transform:rotate(45deg)}.nav[_ngcontent-%COMP%]   .display-block[_ngcontent-%COMP%]{display:block}@keyframes _ngcontent-%COMP%_fade{0%{opacity:.6}to{opacity:1}}.width200[_ngcontent-%COMP%]{width:200px!important}.width75[_ngcontent-%COMP%]{width:75px!important}.animateRight[_ngcontent-%COMP%]{animation-name:_ngcontent-%COMP%_animateRight;animation-duration:.3s;animation-fill-mode:forwards}.animateLeft[_ngcontent-%COMP%]{animation-name:_ngcontent-%COMP%_animateLeft;animation-duration:.3s;animation-fill-mode:backwards}@keyframes _ngcontent-%COMP%_animateRight{to{transform:rotate(180deg)}}@keyframes _ngcontent-%COMP%_animateLeft{to{transform:rotate(-180deg)}}"]}),o})(),A=(()=>{class o{constructor(t,n,s,c){this.chatService=t,this.authService=n,this.renderer=s,this.ef=c}ngOnInit(){this.authService.currentUser$.subscribe(t=>{t&&(this.userAuthorizeDto=t)}),this.chatService.CreateChatHubConnection(this.userAuthorizeDto.token)}ngAfterViewInit(){this.renderer.setStyle(this.ef.nativeElement.querySelector(".chat"),"height",window.innerHeight-70+"px")}ngOnDestroy(){this.chatService.chatHubStop()}}return o.\u0275fac=function(t){return new(t||o)(e.Y36(C.a),e.Y36(x.e),e.Y36(e.Qsj),e.Y36(e.SBq))},o.\u0275cmp=e.Xpm({type:o,selectors:[["chat-c"]],decls:4,vars:0,consts:[[1,"chat"],[1,"chat-body"]],template:function(t,n){1&t&&(e.TgZ(0,"div",0),e._UZ(1,"chat-nav"),e.TgZ(2,"div",1),e._UZ(3,"router-outlet"),e.qZA()())},dependencies:[u.lC,D],styles:[".chat[_ngcontent-%COMP%]{display:flex;background:rgba(255,255,255,.7);width:100%;overflow:hidden}.chat[_ngcontent-%COMP%]   .chat-body[_ngcontent-%COMP%]{width:100%;height:100%;overflow:hidden}"]}),o})();var k=r(5592),a=r(95),T=r(4019),B=r(6448),E=r(1975),I=r(6553);function R(o,i){if(1&o&&(e.TgZ(0,"div",18),e._UZ(1,"img",16)(2,"span",19),e.ALo(3,"async"),e.qZA()),2&o){const t=e.oxw();e.xp6(1),e.hYB("src","",t.backendUrlPicture,"",null==t.userDtoResponder||null==t.userDtoResponder.userPictureDto?null:t.userDtoResponder.userPictureDto.pictureUrl,"",e.LSH),e.xp6(1),e.ekj("display-block",e.lcZ(3,4,t.presenceService.usersOnline$).includes(t.userDtoResponder.phoneNumber))}}function F(o,i){if(1&o&&e._UZ(0,"div",29),2&o){const t=e.oxw().$implicit,n=e.oxw();e.Udp("border-left-color",t.responderPhoneNumber!=(null==n.userDtoResponder?null:n.userDtoResponder.phoneNumber)?"lightgreen":"")}}function U(o,i){1&o&&e._UZ(0,"div",30)}function Y(o,i){if(1&o&&(e.TgZ(0,"div",31),e._UZ(1,"img",32),e.qZA()),2&o){const t=e.oxw().$implicit,n=e.oxw();e.xp6(1),e.hYB("src","",n.backendUrlPicture,"",t.pictureUrl,"",e.LSH)}}function L(o,i){1&o&&e._UZ(0,"i",33)}function J(o,i){1&o&&e._UZ(0,"i",34)}function z(o,i){if(1&o&&(e.TgZ(0,"div",20)(1,"div",21),e.YNc(2,F,1,2,"div",22),e.YNc(3,U,1,0,"div",23),e.TgZ(4,"div",24),e.YNc(5,Y,2,2,"div",25),e._uU(6),e.qZA(),e.TgZ(7,"div",26),e.YNc(8,L,1,0,"i",27),e.YNc(9,J,1,0,"i",28),e.qZA()()()),2&o){const t=i.$implicit,n=e.oxw();e.xp6(1),e.Udp("background-color",t.responderPhoneNumber!=(null==n.userDtoResponder?null:n.userDtoResponder.phoneNumber)?"lightgreen":""),e.xp6(1),e.Q6J("ngIf",t.responderPhoneNumber!=(null==n.userDtoResponder?null:n.userDtoResponder.phoneNumber)),e.xp6(1),e.Q6J("ngIf",t.responderPhoneNumber==(null==n.userDtoResponder?null:n.userDtoResponder.phoneNumber)),e.xp6(2),e.Q6J("ngIf",t.pictureUrl),e.xp6(1),e.hij(" ",null!=t.content&&"null"!=t.content?t.content:""," "),e.xp6(2),e.Q6J("ngIf",0==t.isRead),e.xp6(1),e.Q6J("ngIf",1==t.isRead)}}const G=[{path:"",component:A,children:[{path:":PhoneNumber",component:(()=>{class o{constructor(t,n,s,c,d,f,m){this.chatService=t,this.activatedRoute=n,this.router=s,this.userService=c,this.presenceService=d,this.ef=f,this.toastService=m,this.backendUrlPicture=g.N.setting.url.backendUrlPicture,this.messageAddForm=new a.cw({content:new a.NI(null,[a.kI.required]),file:new a.NI("",[a.kI.required]),fileSource:new a.NI("",[a.kI.required])})}ngOnInit(){this.handleChangeRoute(),this.responderPhoneNumber=this.activatedRoute.snapshot.paramMap.get("PhoneNumber"),this.GroupAdd(),this.userResponderGet()}onFileChange(t){let n=new FileReader;if(t.target.files.length>0){let s=null;s=t.target.files[0],this.compress(s,800,800).subscribe(c=>{this.messageAddForm.patchValue({fileSource:c})}),n.readAsDataURL(s),n.onload=()=>{this.urlPicture=n.result}}this.pictureShowDelete()}compress(t,n,s){const c=t.type||"image/jpeg",d=new FileReader;return d.readAsDataURL(t),k.y.create(f=>{d.onload=m=>{const h=this.createImage(m);setTimeout(()=>{const l=document.createElement("canvas");h.height<h.width?(l.width=s&&h.width>s?s:h.width,l.height=n&&h.height>n?n:h.height):(l.height=n&&h.height>n?n:h.height,l.width=s?50*l.height/100:l.width);const M=l.getContext("2d");M.drawImage(h,0,0,l.width,l.height),M.canvas.toBlob($=>{f.next(new File([$],t.name,{type:c,lastModified:Date.now()}))},c)})},d.onerror=m=>f.error(m)})}createImage(t){const n=t.target.result,s=new Image;return s.src=n,s}GroupAdd(){this.intervalReloadGroup=setInterval(()=>{this.chatService.chatHub.state==B.A.Connected&&this.chatService.groupAdd(this.responderPhoneNumber).subscribe(t=>{t&&(localStorage.setItem(g.N.storage.groupName,t.name),t&&clearInterval(this.intervalReloadGroup),this.messageGetAll())})},500)}userResponderGet(){let t=new T.C;t.searchPhoneNumber=this.responderPhoneNumber,this.userService.userSearchDtoSet(t),this.userService.userGetAll().subscribe(n=>{this.userDtoResponder=n.data[0]})}handleChangeRoute(){this.subscription&&this.subscription.unsubscribe(),this.subscription=this.router.events.subscribe(t=>{t instanceof u.m2&&this.ngOnInit()})}messageAdd(){if(this.messageAddForm.controls.fileSource.errors&&this.messageAddForm.controls.content.errors)return void this.toastService.error(g.N.messages.common.messageEmpty);const t=new FormData;t.append("picture",this.messageAddForm.get("fileSource").value),t.append("content",this.messageAddForm.get("content").value),t.append("responderPhoneNumber",this.responderPhoneNumber),t.append("groupName",localStorage.getItem(g.N.storage.groupName)),this.chatService.messageAdd(t).subscribe(),this.messageAddForm.reset(),this.pictureDontShowDelete(),this.messageAddForm.controls.fileSource.reset(),this.messageAddForm.controls.file.reset(),this.urlPicture=null,this.ef.nativeElement.getElementsByClassName("input-picture")[0].value=null}showFile(){this.ef.nativeElement.getElementsByClassName("input-picture")[0].click()}messageGetAll(){let t=new E.a;t.groupName=localStorage.getItem(g.N.storage.groupName),t.isRead=I.v.notImportant,this.chatService.messageSearchDtoSet(t),this.chatService.messageGetAll().subscribe(n=>{n&&(this.chatService.messageDtos.next(n.data),this.scrollToEnd())})}pictureShowDelete(){let t,n;t=this.ef.nativeElement.getElementsByClassName("btn-picture")[0],t.classList.add("displayNone"),t.classList.remove("displayBlock"),n=this.ef.nativeElement.getElementsByClassName("urlPicture")[0],n.classList.add("displayBlock"),n.classList.remove("DisplayNone")}pictureDontShowDelete(){let t,n;t=this.ef.nativeElement.getElementsByClassName("btn-picture")[0],t.classList.add("displayBlock"),t.classList.remove("displayNone"),n=this.ef.nativeElement.getElementsByClassName("urlPicture")[0],n.classList.add("displayNone"),n.classList.remove("displayBlock")}urlPictureDelete(){confirm(g.N.messages.common.doYouWantToCancelSendThisPicture)&&(this.pictureDontShowDelete(),this.messageAddForm.controls.fileSource.reset(),this.messageAddForm.controls.file.reset(),this.urlPicture=null,this.ef.nativeElement.getElementsByClassName("input-picture")[0].value=null)}scrollToEnd(){this.divShowMessage=this.ef.nativeElement.getElementsByClassName("show-message")[0],setTimeout(()=>{this.divShowMessage.scroll({top:this.divShowMessage.scrollHeight,behavior:"smooth"})})}ngOnDestroy(){this.subscription&&this.subscription.unsubscribe()}}return o.\u0275fac=function(t){return new(t||o)(e.Y36(C.a),e.Y36(u.gz),e.Y36(u.F0),e.Y36(P.K),e.Y36(b.Q),e.Y36(e.SBq),e.Y36(O._W))},o.\u0275cmp=e.Xpm({type:o,selectors:[["chat-body"]],decls:21,vars:8,consts:[[1,"header-chat"],[1,"information"],[1,"name"],[1,"user-role"],["class","image",4,"ngIf"],[1,"show-message"],["class","message-container",4,"ngFor","ngForOf"],[1,"send-message"],[3,"formGroup","ngSubmit"],["type","submit",1,"btn-send"],[1,"fa","fa-play"],["type","text","formControlName","content",1,"input-text"],["type","file","id","",1,"input-picture",3,"change"],[1,"btn-picture",3,"click"],[1,"fa","fa-paperclip"],[1,"urlPicture"],["alt","",3,"src"],[1,"fa","fa-minus-circle",3,"click"],[1,"image"],[1,"show-online-user"],[1,"message-container"],[1,"message-float"],["class","right",3,"border-left-color",4,"ngIf"],["class","left",4,"ngIf"],[1,"message"],["class","message-picture",4,"ngIf"],[1,"read"],["class","fa-solid fa-check","style","color: rgba(100,100,100,.7)",4,"ngIf"],["class","fa-solid fa-check","style","color: green",4,"ngIf"],[1,"right"],[1,"left"],[1,"message-picture"],["alt","","width","200px","height","200px",3,"src"],[1,"fa-solid","fa-check",2,"color","rgba(100,100,100,.7)"],[1,"fa-solid","fa-check",2,"color","green"]],template:function(t,n){1&t&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2),e._uU(3),e.qZA(),e.TgZ(4,"div",3),e._uU(5),e.qZA()(),e.YNc(6,R,4,6,"div",4),e.qZA(),e.TgZ(7,"div",5),e.YNc(8,z,10,8,"div",6),e.ALo(9,"async"),e.qZA(),e.TgZ(10,"div",7)(11,"form",8),e.NdJ("ngSubmit",function(){return n.messageAdd()}),e.TgZ(12,"button",9),e._UZ(13,"i",10),e.qZA(),e._UZ(14,"input",11),e.TgZ(15,"input",12),e.NdJ("change",function(c){return n.onFileChange(c)}),e.qZA(),e.TgZ(16,"span",13),e.NdJ("click",function(){return n.showFile()}),e._UZ(17,"i",14),e.qZA(),e.TgZ(18,"span",15),e._UZ(19,"img",16),e.TgZ(20,"i",17),e.NdJ("click",function(){return n.urlPictureDelete()}),e.qZA()()()()),2&t&&(e.xp6(3),e.Oqu(null==n.userDtoResponder?null:n.userDtoResponder.username),e.xp6(2),e.Oqu(null==n.userDtoResponder?null:n.userDtoResponder.description),e.xp6(1),e.Q6J("ngIf",null==n.userDtoResponder?null:n.userDtoResponder.userPictureDto),e.xp6(2),e.Q6J("ngForOf",e.lcZ(9,6,n.chatService.messageDtos$)),e.xp6(3),e.Q6J("formGroup",n.messageAddForm),e.xp6(8),e.s9C("src",n.urlPicture,e.LSH))},dependencies:[p.sg,p.O5,a._Y,a.Fj,a.JJ,a.JL,a.sg,a.u,p.Ov],styles:[".header-chat[_ngcontent-%COMP%]{width:100%;height:65px;display:flex;align-items:center;background-color:#fffc}.header-chat[_ngcontent-%COMP%]   .image[_ngcontent-%COMP%]{width:60px;height:60px;border:1px solid black;overflow:hidden;border-radius:5px;position:relative}.header-chat[_ngcontent-%COMP%]   .image[_ngcontent-%COMP%]   img[_ngcontent-%COMP%]{width:60px;height:60px}.header-chat[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]{height:100%;width:calc(100% - 65px)}.header-chat[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]   div[_ngcontent-%COMP%]{text-align:center;height:50%}.header-chat[_ngcontent-%COMP%]   .information[_ngcontent-%COMP%]   .user-role[_ngcontent-%COMP%]{font-size:10px}.show-message[_ngcontent-%COMP%]{width:100%;height:calc(100% - 115px);background-color:#c8c8c8f2;overflow:scroll}.show-message[_ngcontent-%COMP%]   .message-picture[_ngcontent-%COMP%]{text-align:center}.show-message[_ngcontent-%COMP%]   .message-container[_ngcontent-%COMP%]{margin-top:10px;margin-bottom:10px}.show-message[_ngcontent-%COMP%]   .message-container[_ngcontent-%COMP%]   .message-float[_ngcontent-%COMP%]{background:lightblue;width:80%;border-radius:5px;padding:5px;margin:0 auto;position:relative}.show-message[_ngcontent-%COMP%]   .message-container[_ngcontent-%COMP%]   .message-float[_ngcontent-%COMP%]   .right[_ngcontent-%COMP%]{width:30px;height:30px;position:absolute;right:-30px;border-top:12px solid transparent;border-bottom:12px solid transparent;border-left:30px solid lightblue}.show-message[_ngcontent-%COMP%]   .message-container[_ngcontent-%COMP%]   .message-float[_ngcontent-%COMP%]   .left[_ngcontent-%COMP%]{width:30px;height:30px;position:absolute;left:-30px;border-top:12px solid transparent;border-bottom:12px solid transparent;border-right:30px solid lightblue}.send-message[_ngcontent-%COMP%]{width:100%;height:50px;position:relative}.send-message[_ngcontent-%COMP%]   .input-picture[_ngcontent-%COMP%]{display:none}.send-message[_ngcontent-%COMP%]   .btn-picture[_ngcontent-%COMP%]{top:0;left:0;z-index:4;position:absolute;color:#6495ed;font-size:27px;line-height:55px;width:35px;height:50px}.send-message[_ngcontent-%COMP%]   .urlPicture[_ngcontent-%COMP%]{top:0;left:0;z-index:4;position:absolute;color:#6495ed;font-size:27px;line-height:55px;width:50px;height:50px;display:none;text-align:center}.send-message[_ngcontent-%COMP%]   .urlPicture[_ngcontent-%COMP%]   img[_ngcontent-%COMP%]{width:50Px;height:50px}.send-message[_ngcontent-%COMP%]   .urlPicture[_ngcontent-%COMP%]   i[_ngcontent-%COMP%]{position:absolute;width:50px;height:50px;top:0;left:0;color:red;font-size:27px;line-height:55px}.send-message[_ngcontent-%COMP%]   .btn-send[_ngcontent-%COMP%]{color:#6495ed;font-size:27px;line-height:55px;width:50px;height:50px}.send-message[_ngcontent-%COMP%]   .input-text[_ngcontent-%COMP%]{padding-right:10px;padding-left:30px;width:calc(100% - 50px);height:50px;transform:translateY(-7px)}.show-online-user[_ngcontent-%COMP%]{width:10px;height:10px;background-color:green;border-radius:50%;position:absolute;bottom:0;left:0;z-index:2;display:none;animation-name:_ngcontent-%COMP%_fade;animation-duration:.3s;animation-direction:alternate-reverse;animation-iteration-count:infinite}.display-block[_ngcontent-%COMP%]{display:block}@keyframes _ngcontent-%COMP%_fade{0%{opacity:.6}to{opacity:1}}"]}),o})()}]}];let Q=(()=>{class o{}return o.\u0275fac=function(t){return new(t||o)},o.\u0275mod=e.oAB({type:o}),o.\u0275inj=e.cJS({imports:[u.Bz.forChild(G),u.Bz]}),o})(),q=(()=>{class o{}return o.\u0275fac=function(t){return new(t||o)},o.\u0275mod=e.oAB({type:o}),o.\u0275inj=e.cJS({imports:[p.ez,Q,a.UX]}),o})()}}]);