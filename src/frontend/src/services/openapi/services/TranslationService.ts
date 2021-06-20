/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Translation } from '../models/Translation';
import { request as __request } from '../core/request';

export class TranslationService {

    /**
     * @returns Translation Success
     * @throws ApiError
     */
    public static async getTranslationService(): Promise<Array<Translation>> {
        const result = await __request({
            method: 'GET',
            path: `/Translation`,
        });
        return result.body;
    }

}