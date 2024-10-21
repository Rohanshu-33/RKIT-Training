# Bootstrap Documentation

## 1. Breakpoints

Breakpoints in Bootstrap allow for responsive design, ensuring layouts adjust at specific screen widths.

- **Extra small devices**: `<576px`
  
- **Small devices**: `≥576px`

- **Medium devices**: `≥768px`

- **Large devices**: `≥992px`

- **Extra large devices**: `≥1200px`

- **Extra extra large devices**: `≥1400px`

Breakpoints are useful for making layouts responsive across different screen sizes.

---

## 2. Containers

Containers are used to wrap content and provide responsive layout support. Bootstrap includes three main container types:

- **`.container`**: Fixed-width, responsive container, adjusting according to the screen size.
- **`.container-fluid`**: A full-width container, spanning the entire width of the viewport.
- **`.container-{breakpoint}`**: Responsive containers that adjust at a specific breakpoint, e.g., `.container-md`.

```html
<div class="container"> ... </div>
<div class="container-fluid"> ... </div>
<div class="container-md"> ... </div>
```

---

## 3. Row

A **row** is used within a container to create a grid layout. It wraps columns and ensures correct alignment.

```html
<div class="container">
  <div class="row">
    <!-- Columns go here -->
  </div>
</div>
```

Rows must be used within a container, and columns must be placed inside rows for proper alignment.

---

## 4. Col (Column)

Columns allow for the division of the horizontal space in a row. Bootstrap’s grid system is built on a 12-column layout.

- **`.col`**: Auto-sizing column that divides equally.
- **`.col-{size}-{n}`**: Defines the number of columns the element should span, e.g., `.col-md-4` spans 4 columns at the `md` breakpoint.

```html
<div class="row">
  <div class="col-md-4">Column 1</div>
  <div class="col-md-4">Column 2</div>
  <div class="col-md-4">Column 3</div>
</div>
```

---

## 5. Grid System

Bootstrap’s grid system uses a series of containers, rows, and columns to layout and align content. It’s fully responsive and adapts to different screen sizes based on breakpoints.

- **Grid Layout**: A grid layout can have a maximum of 12 columns per row.
  
Key Classes:
- `.container`, `.container-fluid` for the container.
- `.row` to define rows.
- `.col`, `.col-{size}-{n}` for columns.

---

## 6. Utility Classes

Utility classes in Bootstrap allow you to modify components and elements quickly. Some commonly used utility classes include:

### Spacing Utilities
- **Padding**: `.p-{n}`, `.pt-{n}`, `.pb-{n}`, `.ps-{n}`, `.pe-{n}`
- **Margin**: `.m-{n}`, `.mt-{n}`, `.mb-{n}`, `.ms-{n}`, `.me-{n}`

### Text Utilities
- **Text alignment**: `.text-left`, `.text-center`, `.text-right`
- **Text color**: `.text-primary`, `.text-danger`, `.text-warning`, `.text-dark`, `.text-light`, `.text-info`

### Display Utilities
- **Display**: `.d-block`, `.d-inline-block`, `.d-none`, `.d-flex`, `.d-grid`

### Background Utilities
- **Background colors**: `.bg-primary`, `.bg-success`, `.bg-warning`, `.bg-light`, `.bg-dark`, `.bg-info`

---

## 7. Basic Important Classes

Here’s a list of some of the most common and important classes in Bootstrap:

- **Grid**:
  - `.container`, `.container-fluid`
  - `.row`
  - `.col`, `.col-sm-{n}`, `.col-md-{n}`, `.col-lg-{n}`

- **Typography**:
  - `.text-left`, `.text-right`, `.text-center`
  - `.font-weight-bold`, `.font-italic`


- **Buttons**:
  - `.btn`, `.btn-primary`, `.btn-secondary`, `.btn-danger`, `.btn-success`

- **Display**:
  - `.d-none`, `.d-block`, `.d-inline-block`
  - `.d-flex`, `.d-grid`

- **Visibility**:
  - `.visible`, `.invisible`

- **Alignment**:
  - `.align-items-start`, `.align-items-center`, `.align-items-end`
  - `.justify-content-start`, `.justify-content-center`, `.justify-content-end`

---