import { inject, Injectable } from "@angular/core";
import { TodoItem } from "../models/todo-item";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class TodoService {
  private readonly apiUrl = 'https://localhost:7196/api/v1/ToDoItems';
  private readonly http = inject(HttpClient);

  getTodoItems(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.apiUrl);
  }

  addTodoItem(itemName: string): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.apiUrl, { itemName });
  }

  deleteTodoItem(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
