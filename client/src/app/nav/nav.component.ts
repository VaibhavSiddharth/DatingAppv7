import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model:any={}  
  constructor(public accountservice: AccountService, private router:Router, private toastr:ToastrService) { }

  ngOnInit(): void {
    
  }


  login(){
    this.accountservice.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/members')      
    })
  }

  logout(){
    this.accountservice.logout(); 
    this.router.navigateByUrl('/')   
  }
}
