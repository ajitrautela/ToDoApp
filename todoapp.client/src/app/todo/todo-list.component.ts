import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService } from '../services/todo.service';
import { TodoItem } from '../models/todo-item';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list.component.html'
})
export class TodoListComponent implements OnInit {
  private readonly todoService = inject(TodoService);

  todos: TodoItem[] = [];
  newItemName = '';
  isLoading = false;
  error: string | null = null;

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.isLoading = true;
    this.error = null;
    this.todoService.getTodoItems().subscribe({
      next: todos => {
        this.todos = todos;
        this.isLoading = false;
      },
      error: () => {
        this.error = 'Failed to load items';
        this.isLoading = false;
      },
    });
  }

  addTodoItem(): void {
    const itemName = this.newItemName.trim();
    if (!itemName) return;

    this.todoService.addTodoItem(itemName).subscribe({
      next: todo => {
        this.todos = [...this.todos, todo];
        this.newItemName = '';
      },
      error: () => (this.error = 'Failed to add item.'),
    });
  }

  deleteTodoItem(id: number): void {
    this.todoService.deleteTodoItem(id).subscribe({
      next: () => {
        this.todos = this.todos.filter(t => t.id !== id);
      },
      error: () => (this.error = 'Failed to delete item.'),
    });
  }
}
