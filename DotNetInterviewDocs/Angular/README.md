# Angular

Interview questions covering Angular fundamentals and advanced scenarios with detailed explanations and examples.

## 1️⃣ What is Angular?
Angular is a TypeScript-based open-source front-end framework for building single-page applications (SPAs). It provides components, routing, dependency injection, and many other features out of the box.

## 2️⃣ What are the main building blocks of Angular?
- **Modules** – containers for related components, directives, and services
- **Components** – control the view and application logic
- **Templates** – HTML with Angular syntax
- **Services** – shared business logic
- **Directives** – extend HTML functionality
- **Pipes** – transform data in templates
- **Dependency Injection** – manage dependencies

## 3️⃣ What is data binding in Angular?
Data binding connects a component with its view. Angular supports:
- **Interpolation:** `{{ property }}`
- **Property binding:** `[property]="value"`
- **Event binding:** `(event)="handler()"`
- **Two-way binding:** `[(ngModel)]="property"`

Example:
```html
<input [(ngModel)]="username" />
<p>Hello, {{ username }}!</p>
```

## 4️⃣ What are directives? Types of directives?
Directives modify DOM behavior or appearance.
- **Component directive** – declared with `@Component`
- **Structural directive** – modify layout (`*ngIf`, `*ngFor`)
- **Attribute directive** – change appearance (`ngClass`, `ngStyle`)

## 5️⃣ Explain lifecycle hooks.
Angular components provide hooks such as `ngOnInit`, `ngOnChanges`, `ngDoCheck`, and `ngOnDestroy` to respond to key lifecycle events.
```typescript
ngOnInit() { console.log('Component initialized'); }
ngOnDestroy() { console.log('Component destroyed'); }
```

## 6️⃣ What is Angular CLI?
A command line tool to scaffold, build, test, and deploy Angular apps.
- `ng new` – create a new app
- `ng serve` – start a development server
- `ng generate component` – create a new component
- `ng build --prod` – production build

## 7️⃣ What are services & dependency injection?
Services encapsulate reusable logic. Dependency injection provides them to components automatically.
```typescript
@Injectable()
export class MyService { getData() { /*...*/ } }

@Component({...})
export class MyComponent {
  constructor(private myService: MyService) {}
}
```

## 8️⃣ How do you handle HTTP calls in Angular?
Use the `HttpClient` service.
```typescript
constructor(private http: HttpClient) {}

getUsers() {
  this.http.get('/api/users').subscribe(users => {
    console.log(users);
  });
}
```

## 9️⃣ What are Observables?
Observables from RxJS manage asynchronous data streams such as HTTP calls or events. Use operators like `map` and `catchError` and subscribe to handle emitted values.

Example:
```typescript
this.http.get('/api/data')
  .pipe(map(res => res))
  .subscribe(data => console.log(data));
```

## 🔟 What is routing and how is it configured?
Routing enables navigation without page reloads. Define routes and add a router outlet.
```typescript
const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'home' }
];
```
```html
<router-outlet></router-outlet>
```

## Real-time production scenarios

### Scenario: API Error Handling in HTTP Calls
Use `catchError` to gracefully handle errors.
```typescript
this.http.get('/api/data').pipe(
  catchError(error => {
    console.error('API error:', error);
    return of([]);
  })
).subscribe(data => console.log(data));
```

### Scenario: Role-Based Access in Routing
Protect routes with guards.
```typescript
@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}
  canActivate(): boolean {
    if (this.auth.isAdmin()) return true;
    this.router.navigate(['/login']);
    return false;
  }
}
```
```typescript
{ path: 'admin', component: AdminComponent, canActivate: [AuthGuard] }
```

### Scenario: Shared State Across Components
Use a shared service with `BehaviorSubject`.
```typescript
@Injectable({ providedIn: 'root' })
export class StateService {
  private dataSubject = new BehaviorSubject<string>('default');
  data$ = this.dataSubject.asObservable();
  updateData(value: string) { this.dataSubject.next(value); }
}
```

### Scenario: Performance Optimization in Large Lists
Use `trackBy` with `*ngFor` and virtual scrolling for large datasets.
```html
<div *ngFor="let item of items; trackBy: trackById">{{ item.name }}</div>
```
```typescript
trackById(index: number, item: any) { return item.id; }
```

### Scenario: Production Build & Deployment
```bash
ng build --prod
```
Deploy the contents of the `dist` folder to your hosting provider and set `<base href="/myapp/">` if hosted in a subdirectory.

## Advanced Angular Questions

### 1️⃣ What are standalone components in Angular 15+?
Standalone components can be used without an `NgModule` and declare their own dependencies.
```typescript
@Component({
  standalone: true,
  selector: 'app-standalone',
  template: `<h1>Hello from Standalone!</h1>`,
  imports: [CommonModule]
})
export class StandaloneComponent {}
```
Benefits include faster bootstrapping and reduced boilerplate.

### 2️⃣ How does Change Detection work in Angular?
Angular checks for changes after events, HTTP calls, or timers. Using `ChangeDetectionStrategy.OnPush` limits checks to input changes or component events for better performance.

### 3️⃣ Difference between ngOnChanges and ngDoCheck
`ngOnChanges` fires only on changes to input-bound properties, while `ngDoCheck` runs on every change detection cycle, allowing custom checks.

### 4️⃣ What is Ahead-of-Time (AOT) compilation?
AOT compiles templates during build time for smaller bundles and faster rendering.
```
ng build --aot
```

### 5️⃣ What is ngZone?
`NgZone` tracks asynchronous tasks to trigger change detection. Use `runOutsideAngular` to execute code without triggering change detection for performance.

### 6️⃣ ViewChild vs ContentChild
`ViewChild` queries elements inside a component's own template, while `ContentChild` queries projected content.

### 7️⃣ What is lazy loading?
Lazy loading loads feature modules only when needed using `loadChildren` in the route definition to reduce initial bundle size.

### 8️⃣ Reactive forms vs template-driven forms
Reactive forms define the model in TypeScript (using `FormGroup`, `FormControl`), whereas template-driven forms rely on the template with `ngModel`.

### 9️⃣ Explain the async pipe
The `async` pipe subscribes to an `Observable` or `Promise` in a template and automatically unsubscribes to avoid memory leaks.

### 🔟 How to handle large bundles?
Use lazy loading, tree-shaking, AOT compilation, `OnPush` change detection, trackBy, and the CDK virtual scrolling module. Build with:
```
ng build --prod --optimization
```

