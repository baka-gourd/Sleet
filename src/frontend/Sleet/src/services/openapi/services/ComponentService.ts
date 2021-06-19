/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Component } from '../models/Component';
import { request as __request } from '../core/request';

export class ComponentService {

    /**
     * @returns Component Success
     * @throws ApiError
     */
    public static async getComponentService(): Promise<Array<Component>> {
        const result = await __request({
            method: 'GET',
            path: `/Component`,
        });
        return result.body;
    }

}