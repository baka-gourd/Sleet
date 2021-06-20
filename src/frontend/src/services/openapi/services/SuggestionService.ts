/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Suggestion } from '../models/Suggestion';
import { request as __request } from '../core/request';

export class SuggestionService {

    /**
     * @returns Suggestion Success
     * @throws ApiError
     */
    public static async getSuggestionService(): Promise<Array<Suggestion>> {
        const result = await __request({
            method: 'GET',
            path: `/Suggestion`,
        });
        return result.body;
    }

}