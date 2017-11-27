import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/index';
import { ChoicesComponent} from './choices/index';

const appRoutes: Routes = [
  { path: '', component: MainComponent},
  // { path: 'main', component: MainComponent },
  { path: 'choices', component: ChoicesComponent},

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
