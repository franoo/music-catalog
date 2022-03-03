import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  constructor(private albumService: AlbumService, fb:FormBuilder) {
      this.searchForm= fb.group({
        search:['', Validators.required],
        field:['', Validators.required]
      });
      this.searchForm.patchValue({filter:'artist', tc:true});
   }

  searchForm: FormGroup;
  ngOnInit(): void {
  }

  submitForm(){
    console.log(this.searchForm);
    this.albumService.getAlbumsFilter(this.searchForm.controls['search'].value,this.searchForm.controls['field'].value)
  }

}
